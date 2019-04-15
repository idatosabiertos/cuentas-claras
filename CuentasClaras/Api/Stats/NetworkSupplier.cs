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
        public double TotalAmountUYU { get; set; }

        public string Id => $"SUPPLIER-{SupplierId}";
        public double Weight => TotalAmountUYU;

        public NetworkNodeTypes Type => NetworkNodeTypes.Supplier;
    }
}
