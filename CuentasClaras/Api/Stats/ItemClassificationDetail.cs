using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuentasClaras.Api.Stats
{
    public class ItemClassificationDetail
    {
        public int ReleaseItemId { get; set; }
        public string ExternalId { get; set; }
        public int UnitId { get; set; }
        public double UnitValueAmount { get; set; }
        public string UnitName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int? ReleaseId { get; set; }
        public string CurrencyCode { get; set; }
        public double TotalAmountUYU { get; internal set; }
        public double UnitValueAmountUYU { get; internal set; }
        public string SupplierName { get; internal set; }
        public int SupplierId { get; internal set; }
        public string BuyerName { get; internal set; }
        public int BuyerId { get; internal set; }
    }
}
