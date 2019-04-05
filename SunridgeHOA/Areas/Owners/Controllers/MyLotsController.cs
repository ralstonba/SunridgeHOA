using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SunridgeHOA.Areas.Owners.Controllers
{
    [Area("Owners")]
    public class MyLotsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}