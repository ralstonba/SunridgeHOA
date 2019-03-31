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
    public class OwnersController : Controller
    {
        public readonly ApplicationDbContext _db;
        public readonly HostingEnvironment _hostingEnvironment;
        [BindProperty]
        public OwnerViewModel OwnerVM { get; set; }

        public OwnersController(ApplicationDbContext db, HostingEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;

            OwnerVM = new OwnerViewModel()
            {
                Owner = new Owner()
            };
        }

        public async Task<IActionResult> Index()
        {
            var users = _db.ApplicationUsers
                .Include(m => m.Owner);
            return View(await users.ToListAsync());
        }

        //GET Create
        public IActionResult Create(string appUser)
        {
            OwnerVM.User = _db.ApplicationUsers.SingleOrDefault(m => m.Id == appUser);
            return View(OwnerVM);
        }

        //POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create()
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            OwnerVM.Owner.IsBoardMember = false;
            _db.Owners.Add(OwnerVM.Owner);
            await _db.SaveChangesAsync();

            OwnerVM.User = _db.ApplicationUsers.SingleOrDefault(m => m.Id == OwnerVM.User.Id);

            OwnerVM.User.Owner = OwnerVM.Owner;
            await _db.SaveChangesAsync();

            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            var ownersFromDb = _db.Owners.Find(OwnerVM.Owner.ID);

            if(files.Count != 0)
            {
                var uploads = Path.Combine(webRootPath, @"images\OwnerImage");
                var extension = Path.GetExtension(files[0].FileName);

                using (var filestream = new FileStream(Path.Combine(uploads, OwnerVM.Owner.ID + extension), FileMode.Create))
                {
                    files[0].CopyTo(filestream);
                }

                ownersFromDb.Image = @"\" + @"images\OwnerImage" + @"\" + OwnerVM.Owner.ID + extension;
            }
            else
            {
                var uploads = Path.Combine(webRootPath, @"images\OwnerImage" + @"\" + "default_image" + ".jpg");
                System.IO.File.Copy(uploads, webRootPath + @"\" + @"images\OwnerImage" + @"\" + OwnerVM.Owner.ID + ".jpg");
                ownersFromDb.Image = @"\" + @"images\OwnerImage" + @"\" + OwnerVM.Owner.ID + ".jpg";
            }

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //GET EDIT
        public async Task<IActionResult> Edit (string id)
        {
            OwnerVM.User = _db.ApplicationUsers.SingleOrDefault(m => m.Id == id);

            if (OwnerVM.User == null)
            {
                NotFound();
            }

            if (OwnerVM.User.Owner == null)
            {
                return RedirectToAction("Create", new { appUser = id });
            }

            else
            {
                return View(OwnerVM);
            }
        }

    }
}