using ContractMonthlyClaimSystem.Connection;
using ContractMonthlyClaimSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace ContractMonthlyClaimSystem.Controllers
{
    // this controller will control all AM functions regarding the claim
    public class ApprovalController : Controller
    {
        
        private readonly ClaimToDbContext _context;

        public ApprovalController(ClaimToDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }
        //only verified claims appear in academic manager view
        public IActionResult ApproveClaims()
        {
            var claims = _context.Claims
                                 .Where(c => c.Status == "Approved")
                                 .Select(claim => new Approval
                                 { 
                                    
                                     ClaimId = claim.ClaimId,
                                     QualificationName = claim.QualificationName,
                                     ModuleCode = claim.ModuleCode,
                                     Group = claim.Group,
                                     LessonDate = claim.LessonDate,
                                     Rate = claim.Rate,
                                     HoursWorked = claim.HoursWorked,
                                     FileName = claim.FileName,
                                     Total = claim.Total,
                                     Semester = claim.Semester,
                                     Status = claim.Status
                                 }).ToList();

            return View(claims);
        }
        
        //academic manager approval
        [HttpPost]

        public IActionResult FinalizeApproval(int id)
        {
           
            var claim = _context.Claims.Find(id);
            
            if (claim != null)
            {
              
                var approvedClaim = new Approval
                {
                    ApprovalID = 1,
                    VerificationId = 1, // Use VerificationId from the Verification object
                    QualificationName = claim.QualificationName,
                    ModuleCode = claim.ModuleCode,
                    Group = claim.Group,
                    LessonDate = claim.LessonDate,
                    Rate = claim.Rate,
                    HoursWorked = claim.HoursWorked,
                    FileName = claim.FileName,
                    ICID = claim.ICID,
                    //PCID = claim.PCID,
                    Total = claim.Total,
                    Semester = claim.Semester,
                    Status = "Approved by AC"

                }; using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    { // Enable IDENTITY_INSERT
                        _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Approvals ON");

                        // Add and save changes
                        _context.Approvals.Add(approvedClaim); 
                        claim.ChangeStatus("Approved by the AC");
                        _context.SaveChanges();
                        // Disable IDENTITY_INSERT
                        _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Approvals OFF");
                        // Commit the transaction
                        transaction.Commit(); TempData["SuccessMessage"] = "Claim has been successfully approved.";
                    }
                    catch (Exception ex)
                    {
                        // Log the error
                        Console.WriteLine(ex.InnerException?.Message);

                        // Rollback the transaction
                        transaction.Rollback();
                        // Handle the error
                        TempData["ErrorMessage"] = "An error occurred while saving the entity changes.";

                    }
                }
            }
            return RedirectToAction("ApproveClaims");
        }
    }
}



