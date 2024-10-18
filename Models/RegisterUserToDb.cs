using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace ContractMonthlyClaimSystem.Models
{
    public class RegisterUserToDb
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string RegID { get; set; } = "";
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
        public string PasswordHash { get; set; }

        public void SetPassword(string Password)
        {
            PasswordHash = PasswordHasher.HashPassword(Password);
        }

        public bool CheckPassword(string Password)
        {
            return PasswordHasher.VerifyPassword(password, PasswordHash);
        }
        [Required, MaxLength(100)]
        public string Role { get; set; } = "";
    }

    //password hashing 
    public class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return $"{Convert.ToBase64String(salt)}.{hashed}";
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            var parts = storedHash.Split('.');
            var salt = Convert.FromBase64String(parts[0]);
            var storedHashedPassword = parts[1];

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed == storedHashedPassword;
        }
    }
}
