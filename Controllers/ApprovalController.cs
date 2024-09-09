using Microsoft.AspNetCore.Mvc;

namespace ContractMonthlyClaimSystem.Controllers
{
    // this controller will control all PC functions regarding the claim
    public class ApprovalController : Controller
    {
        public IActionResult ApproveClaims()
        {
            return View();
        }
    }
}
