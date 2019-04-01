using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using SunridgeHOA.Data;
using SunridgeHOA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunridgeHOA.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MapsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly HostingEnvironment _hostingEnvironment;

        private string WebRootPath { get; set; }
        public Map map { get; set; }
        public MapsController(ApplicationDbContext db, HostingEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
            WebRootPath = hostingEnvironment.WebRootPath;
            map = new Map();
        }

        public IActionResult AddMap()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMapPOST()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Maps", "Home");
            }

            _db.Map.Add(map);
            await _db.SaveChangesAsync();
            return RedirectToAction("Maps", "Home");
        }
    }
}
