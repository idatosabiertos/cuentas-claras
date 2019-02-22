using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CuentasClaras.Model
{
    public class Release
    {
        [Key]
        public int ReleaseId { get; set; }

        public string Ocid { get; set; }
        public string Id { get; set; } //TODO: Rename to ReleaseExternalId
        public string Language { get; set; }
        public string Tag { get; set; }

        public int? TenderId { get; set; }
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
        public int TotalAmount { get; set; }

        //FK
        public int? BuyerId { get; set; }
        public Buyer Buyer { get; set; }
        public int? SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public List<ReleaseItem> ReleaseItems { get; set; }
    }
}
