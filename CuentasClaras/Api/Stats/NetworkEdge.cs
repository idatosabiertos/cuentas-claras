using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuentasClaras.Api.Stats
{
    public class NetworkEdge : INetworkEdge
    {
        public int BuyerId { get; set; }
        public int SupplierId { get; set; }

        public string FromId => $"BUYER-{BuyerId}";
        public string ToId => $"SUPPLIER-{SupplierId}";
    }
}
