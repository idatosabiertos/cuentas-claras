using CuentasClaras.Api.Codes;
using CuentasClaras.Api.Migration;
using CuentasClaras.InputDataModel;
using CuentasClaras.Model;
using CuentasClaras.Services;
using CuentasClaras.Services.Data;
using CuentasClaras.Services.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CuentasClaras.Controllers.Migration
{
    [Route("api/migration")]
    [ApiController]
    public class MigrationController : ControllerBase
    {
        private DataProcessingService dataProcessingService { get; }
        public CuentasClarasContext db { get; }

        private readonly BuyersService buyersService;
        private SuppliersService suppliersService;
        private readonly ClassificationService classificationService;

        public MigrationController(
            DataProcessingService dataProcessingService,
            BuyersService buyersService,
            SuppliersService suppliersService,
            ClassificationService classificationService,
            CuentasClarasContext db)
        {
            this.dataProcessingService = dataProcessingService;
            this.db = db;

            this.buyersService = buyersService;
            this.suppliersService = suppliersService;
            this.classificationService = classificationService;
        }

        [HttpPost()]
        [Route("releases")]
        public void StartMigration([FromBody] MigrationConfig migrationConfig)
        {
            Dictionary<string, Release> releasesDicc = new Dictionary<string, Release>();
            Dictionary<string, List<ReleaseItem>> releasesItemsDicc = new Dictionary<string, List<ReleaseItem>>();

            Dictionary<string, Supplier> suppliersDicc = this.suppliersService.GetAll().ToDictionary(x => x.ExternalId, x => x);
            Dictionary<string, Buyer> buyersDicc = this.buyersService.GetAll().Where(x => x.BuyerExternalId != null).ToDictionary(x => x.BuyerExternalId, x => x);
            Dictionary<string, ReleaseItemClassification> releaseItemsClassification = this.classificationService.GetAll().ToDictionary(x => x.ReleaseItemClassificationExternalId, x => x);

            Regex adjudicacion = new Regex(@"^adjudicacion-([0-9]+)$", RegexOptions.Compiled);


            List<ReleaseInputDataModel> releasesInput = this.dataProcessingService.ItemsFrom<ReleaseInputDataModel>(migrationConfig.DataSource, "releases");
            Dictionary<string, List<AwaItemsInputDataModel>> releaseItemsInputDicc = this.dataProcessingService.ItemsFrom<AwaItemsInputDataModel>(migrationConfig.DataSource, "awa_items")
                .GroupBy(x => x.id)
                .ToDictionary(x => x.Key, x => x.ToList());

            var releases = releasesInput.Where(x => x.buyerId != null)
                .Where(s => adjudicacion.IsMatch(s.id))
                .Select(y => new Release
                {
                    Awards = y.awards,
                    Date = y.date,
                    Id = y.id,
                    InitiationType = y.initiationType,
                    Language = y.language,
                    Ocid = y.ocid,
                    TenderSubmissionMethod = y.tenderSubmissionMethod,
                    Tag = y.tag,
                    TenderDescription = y.tenderDescription,
                    TenderEnquiryPeriodEndDate = y.tenderEnquiryPeriodEndDate,
                    TenderEnquiryPeriodStartDate = y.tenderEnquiryPeriodStartDate,
                    TenderHasEnquiries = this.TenderHasEnqueriesToBool(y.tenderHasEnquiries),
                    TenderId = y.tenderId,
                    TenderProcurementMethod = y.tenderProcurementMethod,
                    TenderProcurementMethodDetails = y.tenderProcurementMethodDetails,
                    TenderProcuringEntityId = y.tenderProcuringEntityId,
                    TenderProcuringEntityName = y.tenderProcuringEntityName,
                    TenderStatus = y.tenderStatus,
                    TenderSubmissionMethodDetails = y.tenderSubmissionMethodDetails,
                    TenderTenderPeriodEndDate = y.tenderTenderPeriodEndDate,
                    TenderTenderPeriodStartDate = y.tenderTenderPeriodStartDate,
                    TenderTitle = y.tenderTitle,
                    ReleaseItems = getReleaseItems(releaseItemsInputDicc, y.id).Select(x =>
                    {
                        return new ReleaseItem()
                        {
                            Description = x.awardsItemsDescription,
                            ExternalId = x.awardsItemsId,
                            Quantity = x.awardsItemsQuantity,
                            ReleaseItemClassificationId = getReleaseItemClassificationId(releaseItemsClassification, x.awardsItemsClassificationId),
                            UnitId = x.awardsItemsUnitId,
                            UnitName = x.awardsItemsUnitName,
                            UnitValueAmount = x.awardsItemsUnitValueAmount,
                            CurrencyCode = x.awardsItemsUnitValueCurrency,
                            SupplierId = suppliersDicc[x.awardsId].SupplierId,
                        };
                    }).ToList(),
                    BuyerId = getBuyerId(buyersDicc, y.buyerId),
                    TotalAmountUYU = getReleaseItems(releaseItemsInputDicc, y.id).Sum(x => x.awardsItemsQuantity * x.awardsItemsUnitValueAmount),
                    DataSource = migrationConfig.DataSource
                });

            this.db.AddRange(releases);
            this.db.SaveChanges();
        }

        private int getBuyerId(Dictionary<string, Buyer> buyersDicc, string buyerIdExternal)
        {
            string[] ids = buyerIdExternal.Split("-");
            int section = Int32.Parse(ids[0]); //INCISO
            int unit = Int32.Parse(ids[1]); //UNIDAD EJECUTORA

            if (buyersDicc.ContainsKey(section.ToString()))
                return buyersDicc[section.ToString()].BuyerId;
            else
                return buyersDicc[buyerIdExternal].BuyerId;
        }

        private List<AwaItemsInputDataModel> getReleaseItems(Dictionary<string, List<AwaItemsInputDataModel>> releaseItemsInputDicc, string id)
        {
            if (releaseItemsInputDicc.ContainsKey(id))
                return releaseItemsInputDicc[id];
            else
                return new List<AwaItemsInputDataModel>();
        }

        private int? getReleaseItemClassificationId(Dictionary<string, ReleaseItemClassification> releaseItemsClassification, string awardsItemsClassificationId)
        {
            if (releaseItemsClassification.ContainsKey(awardsItemsClassificationId))
                return releaseItemsClassification[awardsItemsClassificationId].ReleaseItemClassificationId;
            else
            {
                Console.WriteLine("NOT FOUND CLASSIFICATION");
                return null;
            }
        }

        [HttpPost()]
        [Route("buyers")]
        public void Buyers([FromBody] MigrationConfig migrationConfig)
        {
            Regex adjudicacion = new Regex(@"^adjudicacion-([0-9]+)$", RegexOptions.Compiled);

            List<ReleaseInputDataModel> releasesInput = this.dataProcessingService.ItemsFrom<ReleaseInputDataModel>(migrationConfig.DataSource, "releases");

            var buyers = releasesInput
                .Where(s => adjudicacion.IsMatch(s.id) && s.buyerId != null)
                .DistinctBy(d => d.buyerId).ToList();

            List<Buyer> buyersToAdd = new List<Buyer>();

            foreach (var b in buyers)
            {
                string[] ids = b.buyerId.Split("-");
                int section = Int32.Parse(ids[0]); //INCISO
                int unit = Int32.Parse(ids[1]); //UNIDAD EJECUTORA

                if (!this.db.Buyers.Any(x => x.BuyerExternalId == section.ToString() || x.BuyerExternalId == b.buyerId))
                {
                    Buyer buyer = new Buyer();
                    buyer.BuyerExternalId = b.buyerId;
                    buyer.Name = b.buyerName;
                    buyersToAdd.Add(buyer);
                }
            }

            this.db.Buyers.AddRange(buyersToAdd);
            this.db.SaveChanges();
        }

        [HttpPost]
        [Route("sections")]
        public void Sections()
        {

            var buyers = db.Buyers.Select(x => x);

            foreach (var buyer in buyers)
            {
                var aux = buyer.BuyerExternalId.Split("-");
                int buyerExternalId = Int32.Parse(aux[0]);
                buyer.Type = GroupingCodesLongList.Items[TranslatorSectionToGroupingCode.LongList[buyerExternalId]];
            }

            db.SaveChanges();
        }

        [HttpPost()]
        [Route("classifications")]
        public void Classifications([FromBody] MigrationConfig migrationConfig)
        {
            Regex adjudicacion = new Regex(@"^adjudicacion-([0-9]+)$", RegexOptions.Compiled);

            List<AwaItemsInputDataModel> releaseItemsClassification = this.dataProcessingService.ItemsFrom<AwaItemsInputDataModel>(migrationConfig.DataSource, "awa_items");

            var classifications = releaseItemsClassification
                .Where(s => adjudicacion.IsMatch(s.id))
                .DistinctBy(s => s.awardsItemsClassificationId)
                .Select(y => new ReleaseItemClassification
                {
                    Description = y.awardsItemsClassificationDescription,
                    ReleaseItemClassificationExternalId = y.awardsItemsClassificationId
                });


            List<ReleaseItemClassification> classificationsToAdd = new List<ReleaseItemClassification>();

            foreach (var item in classifications)
            {
                if (!this.db.ReleaseItemClassifications.Any(x => x.ReleaseItemClassificationExternalId == item.ReleaseItemClassificationExternalId))
                    classificationsToAdd.Add(item);
            }

            this.db.ReleaseItemClassifications.AddRange(classificationsToAdd);
            this.db.SaveChanges();
        }

        [HttpPost()]
        [Route("suppliers")]
        public void Suppliers([FromBody] MigrationConfig migrationConfig)
        {
            Regex adjudicacion = new Regex(@"^adjudicacion-([0-9]+)$", RegexOptions.Compiled);


            var suppliersSheet = this.dataProcessingService.ItemsFrom<AwaSuppliersInputDataModel>(migrationConfig.DataSource, "awa_suppliers");

            var suppliers = suppliersSheet
                .Where(s => adjudicacion.IsMatch(s.id))
                .GroupBy(x => x.awardsSuppliersId)
                .Select(y => new Supplier
                {
                    Name = y.First().awardsSuppliersName,
                    ExternalId = y.Key
                }).ToList();

            List<Supplier> suppliersToAdd = new List<Supplier>();

            foreach (var item in suppliers)
            {
                if (!this.db.Suppliers.Any(x => x.ExternalId == item.ExternalId))
                    suppliersToAdd.Add(item);
            }

            this.db.Suppliers.AddRange(suppliersToAdd);
            this.db.SaveChanges();
        }

        [HttpPost()]
        [Route("releases/calculate")]
        public void ReleasesCalculate()
        {
            var query = db.Releases.Include(release => release.ReleaseItems);

            var currencies = db.Currencies.Select(x => x).ToList();
            CurrenciesConfig currenciesConfig = new CurrenciesConfig()
            {
                currencies = new Dictionary<int, Dictionary<string, double>>()
            };
            foreach (var item in currencies)
            {
                if (!currenciesConfig.currencies.ContainsKey(item.Year))
                {
                    currenciesConfig.currencies[item.Year] = new Dictionary<string, double>();
                }

                currenciesConfig.currencies[item.Year][item.CurrencyCode] = item.ConversionFactorUYU;
            }

            foreach (var release in query)
            {
                int total = (int)CalculateTotal(release, currenciesConfig);
                release.TotalAmountUYU = total < 0 ? 0 : total;
            }

            db.SaveChanges();
        }

        [HttpPost()]
        [Route("releases/calculate-items")]
        public void ReleasesItemsCalculate()
        {
            var query = db.ReleaseItems.Include(x => x.Release);
            var currencies = db.Currencies.Select(x => x).ToList();
            CurrenciesConfig currenciesConfig = new CurrenciesConfig() {
                currencies = new Dictionary<int, Dictionary<string, double>>()
            };
            foreach (var item in currencies)
            {
                if (!currenciesConfig.currencies.ContainsKey(item.Year)) {
                    currenciesConfig.currencies[item.Year] = new Dictionary<string, double>();
                }

                currenciesConfig.currencies[item.Year][item.CurrencyCode] = item.ConversionFactorUYU;
            }
            
            foreach (var i in query)
            {
                double unitValueAmountUYU = 0;
                int totalValueAmountUYU = 0;

                CalculateTotal(i.Release.DataSource, i, currenciesConfig, out unitValueAmountUYU, out totalValueAmountUYU);

                i.UnitValueAmountUYU = unitValueAmountUYU;
                i.TotalAmountUYU = totalValueAmountUYU;
            }

            db.SaveChanges();
        }


        [HttpPost()]
        [Route("releases/currencies")]
        public void AddCurrencies([FromBody] MigrationConfig migrationConfig)
        {
            var query = db.ReleaseItems.Select(x => x.CurrencyCode).Distinct().ToList();
            foreach (var currencyCode in query)
            {
                if (!String.IsNullOrEmpty(currencyCode))
                {
                    var currency = db.Currencies.Where(x => x.CurrencyCode == currencyCode).FirstOrDefault();
                    if (currency == null)
                        db.Currencies.Add(new Currency()
                        {
                            CurrencyCode = currencyCode
                        });
                }
            }
            db.SaveChanges();
        }

        [HttpPost()]
        [Route("UploadFiles")]
        public async Task<IActionResult> UploadFile()
        {
            var files = Request.Form.Files;
            foreach (var formFile in files)
            {

                using (var ms = formFile.OpenReadStream())
                using (ExcelPackage package = new ExcelPackage(ms))
                {
                    List<OrganisationIndexInputDataModel> rows = package.Workbook.Worksheets["index"].ConvertSheetToObjects<OrganisationIndexInputDataModel>().ToList();

                    string year = rows.Select(x => x.Year).First();

                    var indexesToDelete = this.db.OrganisationIndexes;
                    this.db.OrganisationIndexes.RemoveRange(indexesToDelete);

                    foreach (var x in rows)
                    {

                        var buyerId = this.db.Buyers.Where(b => b.BuyerExternalId == x.OrganisationId).FirstOrDefault()?.BuyerId;

                        this.db.OrganisationIndexes.Add(new Model.OrganisationIndex()
                        {
                            AccumulationOfSuppliersByOrganisation = x.AccumulationOfSuppliersByOrganisation,
                            CompletedInfo = x.CompletedInfo,
                            ConcentrationOfSuppliers = x.ConcentrationOfSuppliers,
                            ConectionByAmount = x.ConectionByAmount,
                            Description = x.Description,
                            OrganisationId = x.OrganisationId,
                            OrganisationName = x.OrganisationName,
                            OrganistationShortName = x.OrganistationShortName,
                            PerformanceIndex = x.PerformanceIndex,
                            Process = x.Process,
                            QuantityOfPurchases = x.QuantityOfPurchases,
                            QuantityOfPurchasesByException = x.QuantityOfPurchasesByException,
                            SanctionedCompanies = x.SanctionedCompanies,
                            Year = x.Year,
                            BuyerId = buyerId,
                        });
                    }

                    db.SaveChanges();
                }
            }

            return Ok();
        }

        private double CalculateTotal(Release release, CurrenciesConfig currencies)
        {
            return release.ReleaseItems.Sum(x =>
            {
                int year = Int32.Parse(release.DataSource);

                double fromReleaseCurrencyToUYUCurrencyFactor = 0;
                try
                {
                    if (x.CurrencyCode != null)
                        fromReleaseCurrencyToUYUCurrencyFactor = currencies.currencies[year][x.CurrencyCode];
                    return x.UnitValueAmount * x.Quantity * fromReleaseCurrencyToUYUCurrencyFactor;
                }
                catch (Exception)
                {
                    return 0;
                }
            });
        }

        private void CalculateTotal(string dataSource, ReleaseItem i, CurrenciesConfig currenciesConfig, out double unitValueAmountUYU, out int totalValueAmountUYU)
        {
            unitValueAmountUYU = 0;
            totalValueAmountUYU = 0;

            int year = Int32.Parse(dataSource);

            double fromReleaseCurrencyToUYUCurrencyFactor = 0;
            try
            {
                if (i.CurrencyCode != null)
                {
                    fromReleaseCurrencyToUYUCurrencyFactor = currenciesConfig.currencies[year][i.CurrencyCode];
                    unitValueAmountUYU = i.UnitValueAmount * fromReleaseCurrencyToUYUCurrencyFactor;
                    totalValueAmountUYU = (int)(unitValueAmountUYU * i.Quantity);
                }
            }
            catch (Exception ex)
            {
            }
        }


        public bool? TenderHasEnqueriesToBool(string tenderHasEnqueries)
        {
            bool auxTenderHasEnqueries = false;
            if (bool.TryParse(tenderHasEnqueries, out auxTenderHasEnqueries))
                return auxTenderHasEnqueries;
            return null;
        }
    }
}