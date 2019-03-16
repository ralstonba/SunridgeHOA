using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SunridgeHOA.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.SignedIn = "true";
            return View();
        }

        public IActionResult Logout()
        {
            ViewBag.SignedIn = "false";
            return RedirectToAction("Index", "Home");
        }

        public IActionResult MyAccount()
        {
            return View();
        }
    }
}