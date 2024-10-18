using ContractMonthlyClaimSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
//PCs approve claims or deny with reason
namespace ContractMonthlyClaimSystem.Controllers
{
    public class VerificationController : Controller
    {
        private readonly ClaimToDbContext _context;

        public VerificationController(ClaimToDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IActionResult VerifyClaims()
        {
                var claims = _context.Claims.ToList();

            //Maps  properties from the claim to the verification model.
            var verificationModels = claims.Select(claim => new Verification
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
                    Status = claim.Status
                }).ToList();

                return View(verificationModels);
            }

        [HttpPost]
        public IActionResult ChangeStatus(int id, string newStatus, string denialReason = null)
        {
            var claim = _context.Claims.Find(id);
            if (claim != null)
            {
                if (newStatus == "Rejected" && !string.IsNullOrEmpty(denialReason))
                {
                    claim.ChangeStatus($"{newStatus} - {denialReason}");
                }
                else
                {
                    claim.ChangeStatus(newStatus);
                }

                _context.SaveChanges();
            }

            return RedirectToAction("VerifyClaims");
        }
    }

    }