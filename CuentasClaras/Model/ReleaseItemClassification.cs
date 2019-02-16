using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CuentasClaras.Model
{
    public class ReleaseItemClassification
    {
        [Key]
        public int ReleaseItemClassificationId { get; set; }
        public string Description { get; set; }
        public string ReleaseItemClassificationExternalId { get; set; }

        public List<ReleaseItem> ReleaseItems { get; set; }
    }
}
