using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuentasClaras.Api.Stats
{
    public class TopProductQuery
    {
        public string Key { get; set; }
        public string Description { get; set; }
        public string DescriptionLong { get; internal set; }
        public string UnitName { get; set; }
        public decimal TotalAmountPerUnit { get; set; }
        public decimal TotalAmountUYU { get; set; }
        public int Quantity { get; set; }
        public int UnitId { get; set; }
        public int ReleaseItemClassificationId { get; set; }
    }
}
