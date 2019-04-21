using CuentasClaras.Api.Codes;
using CuentasClaras.Api.Migration;
using CuentasClaras.InputDataModel;
using CuentasClaras.Model;
using CuentasClaras.Services;
using CuentasClaras.Services.Data;
using CuentasClaras.Services.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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

            Dictionary<string, string> suppliersInputDicc = this.dataProcessingService
                .ItemsFrom<AwaSuppliersInputDataModel>(migrationConfig.DataSource, "awa_suppliers")
                .Where(s => adjudicacion.IsMatch(s.id))
                .DistinctBy(x => x.id)
                .ToDictionary(x => x.id, x => x.awardsSuppliersId);

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
                            CurrencyCode = x.awardsItemsUnitValueCurrency
                        };
                    }).ToList(),
                    BuyerId = buyersDicc[TranslatorSectionToGroupingCode.GetBuyer(y.buyerId, null).BuyerExternalId].BuyerId,
                    SupplierId = getSupplierId(suppliersInputDicc, suppliersDicc, y),
                    TotalAmountUYU = getReleaseItems(releaseItemsInputDicc, y.id).Sum(x => x.awardsItemsQuantity * x.awardsItemsUnitValueAmount)
                });

            this.db.AddRange(releases);
            this.db.SaveChanges();
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

        private int? getSupplierId(Dictionary<string, string> suppliersInputDicc, Dictionary<string, Supplier> suppliersDicc, ReleaseInputDataModel y)
        {
            if (suppliersInputDicc.ContainsKey(y.id))
            {
                if (suppliersDicc.ContainsKey(suppliersInputDicc[y.id]))
                {
                    var x = suppliersDicc[suppliersInputDicc[y.id]].SupplierId;
                    return x;
                }
                else
                    // en la base no existe el supplier 
                    return null;
            }
            else
            {
                //el input de suppliers no contiene el idSupplier, 
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
                .Select(x => TranslatorSectionToGroupingCode.GetBuyer(x))
                .DistinctBy(d => d.BuyerExternalId).ToList();


            if (migrationConfig.CheckIfExists)
            {
                List<Buyer> buyersToAdd = new List<Buyer>();

                foreach (var item in buyers)
                {
                    if (!this.db.Buyers.Any(x => x.Name == item.Name))
                        buyersToAdd.Add(item);
                }

                this.db.Buyers.AddRange(buyersToAdd);
                this.db.SaveChanges();
            }
            else
            {
                this.db.Buyers.AddRange(buyers);
                this.db.SaveChanges();
            }
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


            if (migrationConfig.CheckIfExists)
            {
                List<ReleaseItemClassification> classificationsToAdd = new List<ReleaseItemClassification>();

                foreach (var item in classifications)
                {
                    if (!this.db.ReleaseItemClassifications.Any(x => x.Description == item.Description))
                        classificationsToAdd.Add(item);
                }

                this.db.ReleaseItemClassifications.AddRange(classificationsToAdd);
                this.db.SaveChanges();
            }
            else
            {
                this.db.ReleaseItemClassifications.AddRange(classifications);
                this.db.SaveChanges();
            }
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

            if (migrationConfig.CheckIfExists)
            {
                List<Supplier> suppliersToAdd = new List<Supplier>();

                foreach (var item in suppliers)
                {
                    if (!this.db.Suppliers.Any(x => x.Name == item.Name))
                        suppliersToAdd.Add(item);
                }

                this.db.Suppliers.AddRange(suppliersToAdd);
                this.db.SaveChanges();
            }
            else
            {
                this.db.Suppliers.AddRange(suppliers);
                this.db.SaveChanges();
            }
        }

        [HttpPost()]
        [Route("releases/calculate")]
        public void ReleasesCalculate([FromBody] MigrationConfig migrationConfig)
        {
            Dictionary<string, double> currencies = db.Currencies.ToDictionary(currency => currency.CurrencyCode, currency => currency.ConversionFactorUYU);
            var query = db.Releases.Include(release => release.ReleaseItems);
            foreach (var release in query)
            {
                release.TotalAmountUYU = (int)CalculateTotal(release, currencies);
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
                    var currency = db.Currencies.Find(currencyCode);
                    if (currency == null)
                        db.Currencies.Add(new Currency() {
                            CurrencyCode = currencyCode
                        });
                }
            }
            db.SaveChanges();
        }

        private double CalculateTotal(Release release, Dictionary<string, double> currencies)
        {
            return release.ReleaseItems.Sum(x =>
            {
                if (x.CurrencyCode != null && currencies.ContainsKey(x.CurrencyCode))
                    return x.UnitValueAmount * x.Quantity * currencies[x.CurrencyCode];
                else
                    return 0;
            });
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