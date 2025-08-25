using Microsoft.AspNetCore.Mvc;
using On_line_Store.Models;
using Microsoft.EntityFrameworkCore;
using On_line_Store.Models.view_model;
using Microsoft.Extensions.Logging;

namespace On_line_Store.Controllers
{
    public class UserController : Controller
    {
        ITIContext context;
        public UserController()
        {
            context = new ITIContext();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Getuser()
        {
            var users = context.Users
              .ToList();

            return View(users);
        }
        public IActionResult Details(int id )
        {
            var user = context.Users
                .Where(u => u.UId == id)
                .FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            UserViewmodel uvm = new();
            return View(uvm);
        }

       
        [HttpPost]
        public IActionResult AddUser(UserViewmodel uvm)
        {
            if (ModelState.IsValid)
            {

                User user = new User
                {
                    UId = uvm.Id,
                    UName = uvm.Name,
                    Email = uvm.Email,
                    Phone = uvm.Phone,
                    Address = uvm.Address,

                };
                context.Users.Add(user);
                context.SaveChanges();

                return RedirectToAction("Getuser");
            }
            return View(uvm);

        }
      
        public IActionResult Delete(int id)
        {
            var user = context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            context.Users.Remove(user);
            context.SaveChanges();
            return RedirectToAction("Getuser");
        }
        public IActionResult Edit(int id)
        {
            var user = context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            UserViewmodel uvm = new UserViewmodel
            {
                Id = user.UId,
                Name = user.UName,
                Email = user.Email,
                Phone = user.Phone,
                Address = user.Address,
               
            };
            return View(uvm);
        }
        [HttpPost]
        public IActionResult Edit(UserViewmodel uvm)
        {
            if (ModelState.IsValid)
            {
                return View(uvm);
            }
            var user = context.Users.Find(uvm.Id);
            if (user == null)
            {
                return NotFound();
            }
            user.UName = uvm.Name;
            user.Email = uvm.Email;
            user.Phone = uvm.Phone;
            user.Address = uvm.Address;
            context.SaveChanges();
            return RedirectToAction("Getuser");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserViewmodel uvm)
        {
            if (ModelState.IsValid)
            {
                var user = context.Users
                    .FirstOrDefault(u => u.UName == uvm.Name && u.Email == uvm.Email);
                if (user != null)
                {

                    return RedirectToAction("Getuser");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid email or name.");
                }
            }
            return View(uvm);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserViewmodel uvm)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UId = uvm.Id,
                    UName = uvm.Name,
                    Email = uvm.Email,
                    Phone = uvm.Phone,
                    Address = uvm.Address,
                };
                context.Users.Add(user);
                context.SaveChanges();
                return RedirectToAction("Getuser");
            }
            return View(uvm);
        }
        public IActionResult Logout()
        {
           
            HttpContext.Session.Clear();
            return RedirectToAction("GetUser"); 
        }





    }
}
