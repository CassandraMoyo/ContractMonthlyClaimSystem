using Microsoft.AspNetCore.Mvc;

namespace ContractMonthlyClaimSystem.Controllers
{
    //this controle will update claim related input
    public class ClaimsController : Controller
    {
        public IActionResult EditPersonalDetails()
        {
            return View();
        }
        public IActionResult Claim()
        {
            return View();
        }
        public IActionResult ViewClaims()
        {
            return View();
        }
    }
}
