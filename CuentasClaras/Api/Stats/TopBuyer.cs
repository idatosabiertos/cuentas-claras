using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuentasClaras.Api.Stats
{
    public class TopBuyer
    {
        public int BuyerId { get; set; }
        public string Name { get; set; }
        public int TotalAmount { get; set; }
        public int Quantity { get; set; }
    }
}
