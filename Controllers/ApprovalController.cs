using ContractMonthlyClaimSystem.Models;
using Microsoft.AspNetCore.Mvc;

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
                                     Total = claim.Total,
                                     Semester = claim.Semester,
                                     Status = claim.Status
                                 }).ToList();

            return View(claims);
        }

         [HttpPost]
    public IActionResult FinalizeApproval(int id)
    {
        var claim = _context.Claims.Find(id);
        if (claim != null)
        {
            var approvedClaim = new Approval
            {
                ClaimId = claim.ClaimId,
                QualificationName = claim.QualificationName,
                ModuleCode = claim.ModuleCode,
                Group = claim.Group,
                LessonDate = claim.LessonDate,
                Rate = claim.Rate,
                HoursWorked = claim.HoursWorked,
                FileName = claim.FileName,
                ICID = claim.ICID,
                PCID = claim.PCID,
                Total = claim.Total,
                Semester = claim.Semester,
                Status = "Finalized"
            };

            _context.Approvals.Add(approvedClaim);
            claim.ChangeStatus("Finalized");
            _context.SaveChanges();
        }

        return RedirectToAction("ApproveClaims");
    }
    }
}

