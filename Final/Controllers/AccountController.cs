using Final.Models;
using Final.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Final.Controllers
{
    public class AccountController : Controller
    {
        private readonly FinalContext _context;

        public AccountController(FinalContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.UserModel.ToList());
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                _context.UserModel.Add(userModel);
                _context.SaveChanges();

                ModelState.Clear();
                ViewBag.Message = userModel.FirstName + " " + userModel.LastName + " Successfully registred";
            }
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel userModel)
        {
            var user = _context.UserModel.FirstOrDefault(u => u.username == userModel.username && u.password == userModel.password);
            

            if (user != null)
            {
                HttpContext.Session.SetString("userId", user.id.ToString());
                HttpContext.Session.SetString("userName", user.username.ToString());
                return RedirectToAction("LoggedIn");
            }
            else
            {
                ModelState.AddModelError("", "Username or Password is incorrect");
                return View();
            }
        }

        public ActionResult LoggedIn()
        {
            if (HttpContext.Session.GetString("userId") != null)
            {
                ViewBag.UserName = HttpContext.Session.GetString("userName");
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }


        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public JsonResult IsUserNameAvailabe(string username)
        {
            return Json(!_context.UserModel.Any(x => x.username == username));
        }

    }
}
