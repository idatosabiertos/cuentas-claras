using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CuentasClaras.Model
{
    public class Buyer
    {
        [Key]
        public int BuyerId { get; set; }
        public string Name { get; set; }
        public string BuyerExternalId { get; set; }

        public List<Release> Releases { get; set; }
    }
}
