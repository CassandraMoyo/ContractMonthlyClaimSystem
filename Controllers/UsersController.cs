using ContractMonthlyClaimSystem.Connection;
using ContractMonthlyClaimSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ContractMonthlyClaimSystem.Controllers
{
    public class UsersController : Controller
    {
        private readonly ClaimToDbContext _context;
        //debug with ILogger in final

        public UsersController(ClaimToDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }

        public IActionResult Users()
        {
            var users = _context.Users.ToList();
            return View(users);
        }
        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Register(Registered model)
        {
            if (ModelState.IsValid)
            {
                //string trimmedPassword = model.Password.Trim();
                //model.Password = HashPassword(model.Password);
                _context.Users.Add(model);
                _context.SaveChanges();

                TempData["UserId"] = model.RegID;
                TempData["UserEmail"] = model.Email;

                return RedirectToAction("Login");
            }
            return View(model);
        }
        public IActionResult EditPersonalDetails()
        {
            int userId = (int)TempData["UserId"];
            var user = _context.Users.Find(userId);
            return View(user);
        }

        [HttpPost]
        public IActionResult EditPersonalDetails(Registered model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.Find(model.RegID);
                if (user != null)
                {
                    user.Name = model.Name;
                    user.Surname = model.Surname;
                    user.Contact = model.Contact;
                    user.Address = model.Address;
                    user.Email = model.Email;
                    user.Password = model.Password;

                   /* if (!string.IsNullOrEmpty(model.Password))
                    {
                        // Only hash and update the password if it's been changed
                        user.Password = HashPassword(model.Password);
                    }*/

                    user.Role = model.Role;

                    _context.Users.Update(user);
                    _context.SaveChanges();

                    TempData["SuccessMessage"] = "Details updated successfully!";
                    return RedirectToAction("Login");
                }
            }
            return View(model);
        }



        public IActionResult Login()
        {
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View();
        }

        [HttpPost]
        public IActionResult Login(Registered model)
        {
            //string trimmedPassword = password.Trim();
            Console.WriteLine("Login attempt: Email: " + model.Email + ", Password: " + model.Password);

            var user = _context.Users.SingleOrDefault(u => u.Email == model.Email);

            if (user != null)
            {
                Console.WriteLine("User found: " + user.Email);
                Console.WriteLine("Stored Hashed Password: " + user.Password);
                Console.WriteLine("Entered Password: " + model.Password);

                // if (VerifyPassword(password, user.Password))
                 if (model.Password == user.Password)
                {
                    Console.WriteLine("Password verification successful");

                    TempData["UserId"] = user.RegID;
                    TempData["UserName"] = user.Email;

                    switch (user.Role)
                    {
                        case "Independent Contractor":
                            return RedirectToAction("Claim", "Claims");
                        case "Project Coordinator":
                            return RedirectToAction("VerifyClaims", "Verification");
                        case "Academic Manager":
                            return RedirectToAction("ApproveClaims", "Approval");
                        default:
                            return RedirectToAction("Users");
                    }
                }
                else
                {
                    Console.WriteLine("Password verification failed");
                }
            }
            else
            {
                Console.WriteLine("User not found");
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View();
        }

       /* private string HashPassword(string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            Console.WriteLine("Hashed Password: " + hashedPassword);
            return hashedPassword;
        }

        private bool VerifyPassword(string enteredPassword, string storedHashedPassword)
        {
            bool result = BCrypt.Net.BCrypt.Verify(enteredPassword, storedHashedPassword);
            Console.WriteLine("Password verification result: " + result);
            return result;

        }*/
    }
}