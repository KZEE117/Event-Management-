using Microsoft.AspNetCore.Mvc;
using EventManagement.Data;
using EventManagement.Models;

namespace EventManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly EventDbContext _context;

        public AccountController(EventDbContext context)
        {
            _context = context;
        }

        // ✅ REGISTER
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Admins admin)
        {
            if (string.IsNullOrEmpty(admin.UserName))
            {
                ViewBag.Error = "Username is required.";
                return View();
            }

            var existing = _context.Admins.FirstOrDefault(a => a.UserName == admin.UserName);
            if (existing != null)
            {
                ViewBag.Error = "Username already exists.";
                return View();
            }

            _context.Admins.Add(admin);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        // ✅ LOGIN
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username)
        {
            var user = _context.Admins.FirstOrDefault(a => a.UserName == username);
            if (user == null)
            {
                ViewBag.Error = "User not found. Please register first.";
                return RedirectToAction("Register");
            }

            HttpContext.Session.SetString("UserName", user.UserName);
            return RedirectToAction("Index", "Home");
        }

        // ✅ LOGOUT
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
