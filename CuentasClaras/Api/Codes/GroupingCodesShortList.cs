using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuentasClaras.Api.Codes
{
    public class GroupingCodesShortList
    {
        private static Dictionary<int, string> items = new Dictionary<int, string>() {
            { 1, "Poder Ejecutivo"},
            { 2, "Otros organismos"},
            { 3, "Gobiernos Departamentales"},
        };

        public Dictionary<int, string> Items
        {
            get { return items; }
            set { items = value; }
        }
    }
}
