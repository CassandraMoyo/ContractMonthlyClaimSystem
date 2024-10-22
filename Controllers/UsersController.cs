using ContractMonthlyClaimSystem.Connection;
using ContractMonthlyClaimSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ContractMonthlyClaimSystem.Controllers
{
    public class UsersController : Controller
    {
        private readonly ClaimToDbContext context;

        public UsersController(ClaimToDbContext context)
        {
            this.context = context;
        }

        public IActionResult Users()
        {
            var users = context.Users.ToList();
            return View(users);
        }


        [HttpPost]
        
        public IActionResult createUsers(int? id)//id is nullable as it is auto ++ and hidden, we are passing an id
        {
            
            
           //check if id is null edit if not create a new expense
            if (id != null)
            {
                var expenseInDb = context.Users.SingleOrDefault(x => x.RegID == id);//when edit button is clicked
                                                                                     //it will hold the id of an existing espense with a matching  id
                //return View("expenseInDb");
            }
            
             return View();//id does not exist, return view

        }
        public IActionResult createUsersform(Registered model)
        {
            //if id = 0 ,add new item
            if (model.RegID == 0)
            {
                context.Users.Add(model);
            }
            else
            {
                //if id exists update
                context.Users.Update(model);
            }

             context.SaveChanges();
            
            return RedirectToAction("Users");
        }
    }
}
