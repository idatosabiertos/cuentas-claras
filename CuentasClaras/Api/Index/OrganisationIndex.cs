using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
