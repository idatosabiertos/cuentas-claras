using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuentasClaras.Api.Migration
{
    public class CurrenciesConfig
    {
        //YEAR -> CURRENCY CODE -> VALUE
        public Dictionary<int, Dictionary<string, decimal>> currencies { get; set; }
    }
}
