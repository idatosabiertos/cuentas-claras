using System;
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
        public decimal Description { get; set; }
        public decimal ConectionByAmount { get; set; }
        public decimal SanctionedCompanies { get; set; }
        public decimal Process { get; set; }
        public decimal CompletedInfo { get; set; }
        public decimal ConcentrationOfSuppliers { get; set; }
        public decimal AccumulationOfSuppliersByOrganisation { get; set; }
        public decimal PerformanceIndex { get; set; }
        public decimal QuantityOfPurchasesByException { get; set; }
        public int QuantityOfPurchases { get; set; }
        public int? BuyerId { get; set; }

        public static OrganisationIndex From(Model.OrganisationIndex oi)
        {
            OrganisationIndex o = new OrganisationIndex()
            {
                BuyerId = oi.BuyerId,
                OrganisationId = oi.OrganisationId,
                OrganisationName = oi.OrganisationName,
                OrganistationShortName = oi.OrganistationShortName,
                Description = decimal.Parse(oi.Description),
                AccumulationOfSuppliersByOrganisation = decimal.Parse(oi.AccumulationOfSuppliersByOrganisation),
                CompletedInfo = decimal.Parse(oi.CompletedInfo),
                ConcentrationOfSuppliers = decimal.Parse(oi.ConcentrationOfSuppliers),
                ConectionByAmount = decimal.Parse(oi.ConectionByAmount),
                PerformanceIndex = decimal.Parse(oi.PerformanceIndex),
                Process = decimal.Parse(oi.Process),
                QuantityOfPurchasesByException = decimal.Parse(oi.QuantityOfPurchasesByException),
                QuantityOfPurchases = (int) decimal.Parse(oi.QuantityOfPurchases),
                SanctionedCompanies = decimal.Parse(oi.SanctionedCompanies),
                Year = oi.Year
            };

            return o;
        }

        public static List<OrganisationIndex> From(List<Model.OrganisationIndex> items) => items.Select(r => From(r)).ToList();
    }
}
