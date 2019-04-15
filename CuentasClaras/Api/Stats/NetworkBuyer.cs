using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuentasClaras.Api.Stats
{
    public class NetworkBuyer : INetworkNode
    {
        public string BuyerId { get; set; }
        public string Name { get; set; }
        public double TotalAmountUYU { get; set; }

        public string Id => $"BUYER-{BuyerId}";
        public double Weight => TotalAmountUYU;

        public NetworkNodeTypes Type => NetworkNodeTypes.Buyer;
    }
}
