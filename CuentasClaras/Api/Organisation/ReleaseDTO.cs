using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CuentasClaras.Model
{
    public class ReleaseDTO
    {
        public int ReleaseId { get; set; }

        public string Ocid { get; set; }
        public string ExternalId { get; set; }
        public string Language { get; set; }
        public string Tag { get; set; }

        public string TenderId { get; set; }
        public string TenderProcurementMethodDetails { get; set; }
        public string TenderProcurementMethod { get; set; }
        public string TenderDescription { get; set; }

        public string TenderSubmissionMethodDetails { get; set; }
        public string TenderProcuringEntityId { get; set; }
        public string TenderProcuringEntityName { get; set; }
        public string TenderStatus { get; set; }
        public DateTime? TenderTenderPeriodEndDate { get; set; }
        public DateTime? TenderTenderPeriodStartDate { get; set; }
        public bool? TenderHasEnquiries { get; set; }
        public DateTime? TenderEnquiryPeriodEndDate { get; set; }
        public DateTime? TenderEnquiryPeriodStartDate { get; set; }
        public string TenderTitle { get; set; }
        public string TenderSubmissionMethod { get; set; }

        public DateTime Date { get; set; }
        public string InitiationType { get; set; }
        public string Awards { get; set; }
        public double TotalAmountUYU { get; set; }
        public string DataSource { get; set; }

        public int? BuyerId { get; set; }
        public string BuyerName { get; set; }
        public List<ReleaseItemDTO> ReleaseItems { get; set; }

        public static ReleaseDTO From(Release r)
        {
            ReleaseDTO releaseDTO = new ReleaseDTO();
            releaseDTO.Awards = r.Awards;
            releaseDTO.BuyerId = r.BuyerId;
            releaseDTO.BuyerName = r.Buyer?.Name;
            releaseDTO.Date = r.Date;
            releaseDTO.ExternalId = r.Id;
            releaseDTO.InitiationType = r.InitiationType;
            releaseDTO.Language = r.Language;
            releaseDTO.Ocid = r.Ocid;
            releaseDTO.ReleaseId = r.ReleaseId;
            releaseDTO.Tag = r.Tag;
            releaseDTO.TenderDescription = r.TenderDescription;
            releaseDTO.TenderEnquiryPeriodEndDate = r.TenderEnquiryPeriodEndDate;
            releaseDTO.TenderEnquiryPeriodStartDate = r.TenderEnquiryPeriodStartDate;
            releaseDTO.TenderHasEnquiries = r.TenderHasEnquiries;
            releaseDTO.TenderId = r.TenderId;
            releaseDTO.TenderProcurementMethod = r.TenderProcurementMethod;
            releaseDTO.TenderProcurementMethodDetails = r.TenderProcurementMethodDetails;
            releaseDTO.TenderProcuringEntityId = r.TenderProcuringEntityId;
            releaseDTO.TenderProcuringEntityName = r.TenderProcuringEntityName;
            releaseDTO.TenderStatus = r.TenderStatus;
            releaseDTO.TenderSubmissionMethod = r.TenderSubmissionMethod;
            releaseDTO.TenderSubmissionMethodDetails = r.TenderSubmissionMethodDetails;
            releaseDTO.TenderTitle = r.TenderTitle;
            releaseDTO.TotalAmountUYU = r.TotalAmountUYU;
            releaseDTO.ReleaseItems = ReleaseItemDTO.From(r.ReleaseItems);

            return releaseDTO;
        }

        public static List<ReleaseDTO> From(List<Release> releases) => releases.Select(r => From(r)).ToList();
    }
}
