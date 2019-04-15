using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuentasClaras.Api.Codes
{
    public class GroupingCodesLongList
    {
        private static Dictionary<int, string> items = new Dictionary<int, string>() {
            { 1, "Poder Legislativo"},
            { 2, "Poder Ejecutivo"},
            { 3, "Poder Judicial"},
            { 4, "Organismos con Autonomía Funcional"},
            { 5, "Servicios Descentralizados"},
            { 6, "Entes Autónomo"},
            { 7, "Gobiernos Departamentales"},
        };

        public static Dictionary<int, string> Items
        {
            get { return items; }
        }
    }
}
