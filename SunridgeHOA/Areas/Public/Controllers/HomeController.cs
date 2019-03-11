using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SunridgeHOA.Data;
using SunridgeHOA.Models;

namespace SunridgeHOA.Controllers
{
    [Area("Public")]
    public class HomeController : Controller
    {

        private readonly IEventRepository repository;

        public HomeController(IEventRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Calendar()
        {
            return View();
        }

        public JsonResult GetEvents()
        {
            var events = repository.Events.ToList();
            return new JsonResult(events);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
