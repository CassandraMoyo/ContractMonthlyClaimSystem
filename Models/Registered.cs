using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;

namespace ContractMonthlyClaimSystem.Models
{
    public class Registered
    {
        //getters and setters 
        [Key]
        public int  RegID { get; set; }
        [NotMapped]

        public string RFormattedRegId => $"R{RegID:D3}";
        [Required, MaxLength(100)]
        public string Name { get; set; } = "";
        [Required, MaxLength(100)]
        public string Surname { get; set; } = "";
        [Required, MaxLength(100)]
        public string Contact { get; set; } = "";
        [Required, MaxLength(100)]
        public string Address { get; set; } = "";
        [Required, MaxLength(100)]
        public string Email { get; set; } = "";
        [Required, MaxLength(500)]

        public string Password { get; set; } = "";//hash password

        [Required, MaxLength(100)]
        public string Role { get; set; } = "";
    

    }
}
