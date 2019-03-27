using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SunridgeHOA.Controllers
{
    [Area("Admin")]
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
            ViewBag.SignedIn = "true";
            return View();
        }

        public IActionResult AddSummerPic()
        {
            return View();
        }

        public IActionResult AddWinterPic()
        {
            return View();
        }

        public IActionResult AddPeoplePic()
        {
            return View();
        }
    }
}