using Microsoft.AspNetCore.Mvc;

namespace ContractMonthlyClaimSystem.Controllers
{
    public class ApprovalController : Controller
    {
        public IActionResult ApproveClaims()
        {
            return View();
        }
    }
}
