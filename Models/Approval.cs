using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ContractMonthlyClaimSystem.Models
{
    public class Approval
    {
        [Key]
        public int ApprovalID { get; set; }
        [NotMapped]
        public string FormattedApprovalID => $"A{ApprovalID:D3}"; // Auto-formatted claim ID
        
        public int VerificationId { get; set; }
        public string FormattedVerificationId => $"V{VerificationId:D3}"; // Auto-formatted claim ID
        public int ClaimId { get; set; }
        public string FormattedClaimId => $"CL{ClaimId:D3}"; // Auto-formatted claim ID,count from 001 and +C
        public string Status { get; set; } = "Pending";
        public string DenialReason { get; set; }

        [MaxLength(100)]
        public string QualificationName { get; set; } = "";
        public string ModuleName { get; set; } = "";
        public string ModuleCode { get; set; } = "";
        public string Group { get; set; } = "";
        public DateOnly LessonDate { get; set; }
        public decimal Rate { get; set; }
        public int HoursWorked { get; set; }
        [NotMapped]
        public IFormFile FileUpload { get; set; }
        public string FileName { get; set; }
        public string ICID { get; set; } = "";
        public string PCID { get; set; } = "";
        public decimal Total { get; set; }
        public int Semester { get; set; }
       
    }
}
