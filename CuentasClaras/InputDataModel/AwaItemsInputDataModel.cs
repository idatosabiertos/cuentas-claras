using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuentasClaras.InputDataModel
{
    public class AwaItemsInputDataModel
    {
        public string ocid { get; set; }
        public string id { get; set; }
        public string awardsId { get; set; }
        public string awardsItemsId { get; set; }
        public int awardsItemsUnitId { get; set; }
        public int awardsItemsUnitValueAmount { get; set; }
        public string awardsItemsUnitValueCurrency { get; set; }
        public string awardsItemsUnitName { get; set; }
        public string awardsItemsDescription { get; set; }
        public int awardsItemsQuantity { get; set; }
        public string awardsItemsClassificationId { get; set; }
        public string awardsItemsClassificationDescription { get; set; }
    }
}
