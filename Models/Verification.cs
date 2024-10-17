using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace ContractMonthlyClaimSystem.Models
{
    public class Verification
    {
        [Key]
        public int VerificationId { get; set; }
        [NotMapped]
        public string FormattedVerificationId => $"V{VerificationId:D3}"; // Auto-formatted claim ID
        public int ClaimId { get; set; }
        public string FormattedClaimId => $"CL{ClaimId:D3}"; // Auto-formatted claim ID,count from 001 and +C
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
        public string Status { get; set; } = "Pending";

    
        public void ChangeStatus(string newStatus)
        {
            Status = newStatus;
        }
       
    }

}
