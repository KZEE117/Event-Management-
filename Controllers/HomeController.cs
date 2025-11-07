using Microsoft.AspNetCore.Mvc;

namespace EventManagement.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Faq()
        {
            return View();
        }
        public IActionResult EventReport()
        {
            return View();
        }
       
        public IActionResult Register()
        {
            return View();
        }
    }
}
