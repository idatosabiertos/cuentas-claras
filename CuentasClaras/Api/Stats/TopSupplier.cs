using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuentasClaras.Api.Stats
{
    public class TopSupplier
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public double TotalAmount { get; set; }
        public int Quantity { get; set; }
    }
}
