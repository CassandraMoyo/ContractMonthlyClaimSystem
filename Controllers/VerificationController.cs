using Microsoft.AspNetCore.Mvc;
//PCs approve claims or deny with reason
namespace ContractMonthlyClaimSystem.Controllers
{
    public class VerificationController : Controller
    {
        public IActionResult VerifyClaims()
        {
            return View();
        }
    }
}
