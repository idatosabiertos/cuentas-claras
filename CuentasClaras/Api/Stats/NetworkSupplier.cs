using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuentasClaras.Api.Stats
{
    public class NetworkSupplier : INetworkNode
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public decimal TotalAmountUYU { get; set; }

        public string Id => $"SUPPLIER-{SupplierId}";
        public decimal Weight => TotalAmountUYU;
    }
}
