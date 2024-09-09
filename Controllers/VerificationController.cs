using Microsoft.AspNetCore.Mvc;

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
