using IT_Fusion_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IT_Fusion_MVC.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
