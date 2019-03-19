using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuentasClaras.Api.Stats
{
    public class NetworkBuyer : INetworkNode
    {
        public int BuyerId { get; set; }
        public string Name { get; set; }
        public decimal TotalAmountUYU { get; set; }

        public string Id => $"BUYER-{BuyerId}";
        public decimal Weight => TotalAmountUYU;
    }
}
