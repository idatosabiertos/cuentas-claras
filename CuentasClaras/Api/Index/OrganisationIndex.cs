using System.Collections.Generic;
using System.Linq;

namespace CuentasClaras.Api.Index
{
    public class OrganisationIndex
    {
        public string Year { get; set; }
        public string OrganisationId { get; set; }
        public string OrganistationShortName { get; set; }
        public string OrganisationName { get; set; }
        public string ConectionByAmount { get; set; }
        public string SanctionedCompanies { get; set; }
        public string Process { get; set; }
        public string Description { get; set; }
        public string CompletedInfo { get; set; }
        public string ConcentrationOfSuppliers { get; set; }
        public string AccumulationOfSuppliersByOrganisation { get; set; }
        public string QuantityOfPurchasesByException { get; set; }
        public string PerformanceIndex { get; set; }
        public string QuantityOfPurchases { get; set; }
        public int? BuyerId { get; set; }

        public static OrganisationIndex From(Model.OrganisationIndex oi)
        {
            OrganisationIndex o = new OrganisationIndex()
            {
                AccumulationOfSuppliersByOrganisation = oi.AccumulationOfSuppliersByOrganisation,
                BuyerId = oi.BuyerId,
                CompletedInfo = oi.CompletedInfo,
                ConcentrationOfSuppliers = oi.ConcentrationOfSuppliers,
                ConectionByAmount = oi.ConectionByAmount,
                Description = oi.Description,
                OrganisationId = oi.OrganisationId,
                OrganisationName = oi.OrganisationName,
                OrganistationShortName = oi.OrganistationShortName,
                PerformanceIndex = oi.PerformanceIndex,
                Process = oi.Process,
                QuantityOfPurchases = oi.QuantityOfPurchases,
                QuantityOfPurchasesByException = oi.QuantityOfPurchasesByException,
                SanctionedCompanies = oi.SanctionedCompanies,
                Year = oi.Year
            };

            return o;
        }

        public static List<OrganisationIndex> From(List<Model.OrganisationIndex> items) => items.Select(r => From(r)).ToList();
    }
}
