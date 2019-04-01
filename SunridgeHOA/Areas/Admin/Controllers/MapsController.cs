using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using SunridgeHOA.Data;
using SunridgeHOA.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var mapsFromDb = _db.Map.Find(map.ID);

            var uploads = Path.Combine(webRootPath, @"img\Maps");
            var extension = Path.GetExtension(files[0].FileName);

            using (var filestream = new FileStream(Path.Combine(uploads, map.ID + extension), FileMode.Create))
            {
                files[0].CopyTo(filestream); //Moves to server and renames
            }

            //Save the string image to the database with the image name
            mapsFromDb.FileURL = @"\" + @"img\Maps" + @"\" + map.ID + extension;
            return RedirectToAction("Maps", "Home");
        }
    }
}
