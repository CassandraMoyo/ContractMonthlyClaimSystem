using ContractMonthlyClaimSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace ContractMonthlyClaimSystem.Controllers
{
    //this controle will update claim related input
    public class ClaimsController : Controller
    {

        private readonly ILogger<ClaimsController> _logger;

        //specify dababase
        private readonly ClaimToDbContext _context;//create an object to reference to the database
        private readonly object model;

        public ClaimsController(ILogger<ClaimsController> logger, ClaimToDbContext context)//calling model as in using constructors= instance of controller
        {
            _logger = logger;
            _context = context;
            _context = context ?? throw new ArgumentNullException(nameof(context));


        }
        public IActionResult Claim()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> ClaimsForm(Claims model)
        {
            if (model == null)
            {
                return BadRequest("Model cannot be null");
            }

            //if id = 0 ,add new item
            if (model.ClaimId == 0)
            {
                _context.Claims.Add(model);
            }
            else
            {
                //if id exists update
                _context.Claims.Update(model);
            }

            //semester code
            var currentMonth = DateTime.Now.Month;

            if (currentMonth >= 2 && currentMonth <= 6)
            {
                model.Semester = 1; // Semester 1
            }
            else if (currentMonth >= 7 && currentMonth <= 11)
            {
                model.Semester = 2; // Semester 2
            }
            if (model.FileUpload != null && model.FileUpload.Length > 0)
            {
                var uploadsRootFolder = Path.Combine("claim docs", model.FormattedClaimId);
                Directory.CreateDirectory(uploadsRootFolder);

                var filePath = Path.Combine(uploadsRootFolder, model.FileUpload.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.FileUpload.CopyToAsync(fileStream);
                }

                model.FileName = model.FileUpload.FileName;
            }

            await _context.SaveChangesAsync();
            // Calculate total due
            model.Total = model.HoursWorked * model.Rate;

           // _context.Claims.Add(model);
            _context.SaveChanges();
            return RedirectToAction("ViewClaims");
        }
        [HttpPost]
        public IActionResult SubmitClaim(Claim claim)
        {
            if (ModelState.IsValid)
            {
                // Save claim to the database
               ;
                _context.SaveChanges();

                // Send claim to the VerificationController
                
            }
            return View(claim);
        }


        //clear form
        public IActionResult ClearForm()
        {
            var model = new Claims();  // a new model instance
            return View("Claim", model);  // Return the view with the new model
        }
        //edit claim
        public IActionResult Edit(int id)
        {
            var claim = _context.Claims.Find(id);
            if (claim == null)
            {
                return NotFound();
            }
            return View("Claim", claim);
        }


        // Handle form submission for updates
        [HttpPost]
        public IActionResult Edit(Claims model, int claimId)
        {
            if (ModelState.IsValid)
            {
                var claimToUpdate = _context.Claims.SingleOrDefault(x => x.ClaimId == claimId); // Find the claim by ID
                if (claimToUpdate == null)
                {
                    return NotFound();
                }

                // Update the claim fields
                claimToUpdate.QualificationName = model.QualificationName;
                claimToUpdate.ModuleCode = model.ModuleCode;
                claimToUpdate.Group = model.Group;
                claimToUpdate.LessonDate = model.LessonDate;
                claimToUpdate.HoursWorked = model.HoursWorked;
                claimToUpdate.FileUpload = model.FileUpload;

                _context.SaveChanges();
                return RedirectToAction("ViewClaims", "Verification");
            }
            return View("Claim", model);
        }


        //list view of submitted claim
        public IActionResult ViewClaims(Claims model)
        {
            if (model == null)
            {
                model = new Claims();
            }

            var claims = _context.Claims.ToList();
            string selectedQualification = model.QualificationName;
            string selectedModule = model.ModuleCode;
            int? selectedSemester = model.Semester;
            string selectedGroup = model.Group;
            DateOnly lessonDate = model.LessonDate;
            int hoursWorked = model.HoursWorked;
            decimal rate = model.Rate;

            return View(claims);
        }

        //edit exisiting claim
        [HttpPost]
    public IActionResult EditClaim(Claims model, int claimId)
    {
        if (ModelState.IsValid)
        {
            // Fetch the claim from the database again to avoid any mismatches
            var existingClaim = _context.Claims.SingleOrDefault(x => x.ClaimId == claimId); // Find the claim by ID
                if (existingClaim == null)
            {
                return NotFound();
            }

            // Update properties
            existingClaim.QualificationName = model.QualificationName;
            existingClaim.ModuleCode = model.ModuleCode;
            existingClaim.Group = model.Group;
            existingClaim.LessonDate = model.LessonDate;
            existingClaim.Rate = model.Rate;
            existingClaim.HoursWorked = model.HoursWorked;
            existingClaim.FileName = model.FileName;
            existingClaim.ICID = model.ICID;
            existingClaim.PCID = model.PCID;
            existingClaim.Total = model.Total;
            existingClaim.Semester = model.Semester;
            
            // Change status to resubmitted
            existingClaim.ChangeStatus("Resubmitted");

            _context.Claims.Update(existingClaim);
            _context.SaveChanges();
            return RedirectToAction("ViewSubmittedClaims");
        }
        return View(model);
    }

        public IActionResult EditPersonalDetails()
        {
            return View();
        }
    }
}
