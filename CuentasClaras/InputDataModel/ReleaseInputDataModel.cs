using CuentasClaras.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuentasClaras.InputDataModel
{
    public class ReleaseInputDataModel
    {
        public string ocid { get; set; }
        public string id { get; set; }
        public string language { get; set; }
        public string tag { get; set; }
        public string buyerId { get; set; }
        public string buyerName { get; set; }
        public string tenderId { get; set; }
        public string tenderProcurementMethodDetails { get; set; }
        public string tenderProcurementMethod { get; set; }
        public string tenderDescription { get; set; }
        public string tenderSubmissionMethodDetails { get; set; }
        public string tenderProcuringEntityId { get; set; }
        public string tenderProcuringEntityName { get; set; }
        public string tenderStatus { get; set; }
        public DateTime? tenderTenderPeriodEndDate { get; set; }
        public DateTime? tenderTenderPeriodStartDate { get; set; }
        public string tenderHasEnquiries { get; set; }
        public DateTime? tenderEnquiryPeriodEndDate { get; set; }
        public DateTime? tenderEnquiryPeriodStartDate { get; set; }
        public string tenderTitle { get; set; }
        public string tenderSubmissionMethod { get; set; }
        public DateTime date { get; set; }
        public string initiationType { get; set; }
        public string awards { get; set; }

       
    }
}
