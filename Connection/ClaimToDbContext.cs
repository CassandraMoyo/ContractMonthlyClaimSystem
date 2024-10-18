using ContractMonthlyClaimSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ContractMonthlyClaimSystem.Connection
{
    public class ClaimToDbContext : DbContext
    {
        //connect to db

        //used in memory databased
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

