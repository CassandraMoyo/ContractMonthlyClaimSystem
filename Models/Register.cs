using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContractMonthlyClaimSystem.Models
{
    public class Register
    {
        //getters and setters 
        [Key]
        public string RegID { get; set; } = "";
        [NotMapped]
        public string RFormattedRegId => $"R{RegID:D3}";
        public string Name { get; set; } = "";
        public string Surname { get; set; } = "";
        public string Contact { get; set; } = "";
        public string Address { get; set; } = "";
        public string Email { get; set; } = "";
        public string Passoward { get; set; } = "";
        public string Role { get; set; } = "";

    }
}
