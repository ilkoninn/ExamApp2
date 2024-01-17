using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App2.MVC.Controllers
{
    public class HomeController : Controller
    {

        public async Task<IActionResult> Index()
        {
            return View();
        }

    }
}
