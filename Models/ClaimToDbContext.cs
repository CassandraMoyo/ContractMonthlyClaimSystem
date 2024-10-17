using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ContractMonthlyClaimSystem.Models
{
    public class ClaimToDbContext : DbContext
    {
        public DbSet<Claims> Claims { get; set; }//database creation
        public DbSet<Verification> Verifications { get; set; }
        public DbSet<Approval> Approvals { get; set; }

        public ClaimToDbContext(DbContextOptions<ClaimToDbContext> options) : base(options)//inject info to database
                                                                                           //constructor
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Approval>()
                .HasKey(a => a.ClaimId); // Ensure the primary key is correctly configured

            modelBuilder.Entity<Approval>()
                .Property(a => a.DenialReason)
                .IsRequired(false); // Make DenialReason optional
        }
    }
 }

