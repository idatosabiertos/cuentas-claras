using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuentasClaras.Api.Stats
{
    public class ItemClassification
    {
        public int ReleaseItemClassificationId { get; set; }
        public string Description { get; set; }
        //public string ReleaseItemClassificationExternalId { get; set; }

        //YEAR - CURRENCY - UNIT - DETAIL
        public Dictionary<string, Dictionary<string, List<ItemClassificationDetail>>> ReleaseItems { get; set; }
    }
}
