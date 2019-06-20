using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CuentasClaras.Model
{
    public class ReleaseItemDTO
    {
        public int ReleaseItemId { get; set; }
        public string ExternalId { get; set; }
        public int UnitId { get; set; }
        public double UnitValueAmount { get; set; }
        public string UnitName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double TotalAmountUYU { get; set; }
        //FK
        public int? ClassificationId { get; set; }
        public string Classification { get; set; }
        public string CurrencyCode { get; set; }

        public static ReleaseItemDTO From(ReleaseItem i)
        {
            ReleaseItemDTO dto = new ReleaseItemDTO();
            dto.ReleaseItemId = i.ReleaseItemId;
            dto.CurrencyCode = i.CurrencyCode;
            dto.Description = i.Description;
            dto.ExternalId = i.ExternalId;
            dto.Quantity = i.Quantity;
            dto.ClassificationId = i.ReleaseItemClassificationId;
            dto.Classification = i.ReleaseItemClassification?.Description;
            dto.Description = i.Description;
            dto.TotalAmountUYU = i.TotalAmountUYU;
            dto.UnitId = i.UnitId;
            dto.UnitName = i.UnitName;
            dto.UnitValueAmount = i.UnitValueAmount;

            return dto;
        }

        public static List<ReleaseItemDTO> From(List<ReleaseItem> releaseItems)
        {
            return releaseItems.Select(i => From(i)).ToList();
        }
    }
}
