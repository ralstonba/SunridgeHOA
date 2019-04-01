using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SunridgeHOA.Data;
using SunridgeHOA.Models;
using SunridgeHOA.Models.ViewModels;

namespace SunridgeHOA.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FormsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly HostingEnvironment _hostingEnvironment;

        private string WebRootPath { get; set; }

        public FormsController(ApplicationDbContext db, HostingEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
            WebRootPath = hostingEnvironment.WebRootPath;
        }

        public IActionResult CreateForms()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFormsPOST()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Forms", "Home");
            }
            //_db.Files.Add();
            await _db.SaveChangesAsync();

            var files = HttpContext.Request.Form.Files;

            if (files.Count != 0)
            {
                var uploads = Path.Combine(WebRootPath, @"img\Maps");
                var extension = Path.GetExtension(files[0].FileName);
                //using (var filestream = new FileStream(Path.Combine(uploads, map.ID + extension), FileMode.Create))
                //{
                //    files[0].CopyTo(filestream);
                //}
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Forms", "Home");
        }
    }
}