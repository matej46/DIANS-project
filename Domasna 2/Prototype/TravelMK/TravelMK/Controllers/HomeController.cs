using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TravelMK.Models;

namespace TravelMK.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Favorites()
        {
            return View();
        }

        public IActionResult Navigation()
        {
            return View();
        }

        public IActionResult Placeholder()
        {
            return View();
        }
    }
}