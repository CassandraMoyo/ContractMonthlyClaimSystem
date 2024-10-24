using ContractMonthlyClaimSystem.Connection;
using ContractMonthlyClaimSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ContractMonthlyClaimSystem.Controllers
{
    public class HomeController : Controller
    {
        //specify dababase
        private readonly ClaimToDbContext _context;//create an object to reference to the database
        private readonly object model;

        public HomeController(ILogger<HomeController> logger, ClaimToDbContext context)//calling model as in using constructors= instance of controller
        {
             logger = logger;
            _context = context;
            _context = context ?? throw new ArgumentNullException(nameof(context));


        }
        public IActionResult Index()
        {
            return View();
        }

        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
