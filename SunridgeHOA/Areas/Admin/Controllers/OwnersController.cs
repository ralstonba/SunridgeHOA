using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
                Owner = new Owner(),
                Lots = _db.Lots.ToList(),
                Keys = _db.Keys.ToList()
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

            Address newAddress = new Address();
            newAddress.City = OwnerVM.Owner.Address.City;
            newAddress.State = OwnerVM.Owner.Address.State;
            newAddress.StreetAddress = OwnerVM.Owner.Address.StreetAddress;
            newAddress.Zip = OwnerVM.Owner.Address.Zip;

            OwnerVM.Owner.Address = newAddress;

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

        //GET Edit
        public async Task<IActionResult> Edit (string id)
        {
            OwnerVM.User = _db.ApplicationUsers.SingleOrDefault(m => m.Id == id);
            OwnerVM.Owner = _db.Owners.Include(m => m.Address).SingleOrDefault(m => m.ID == OwnerVM.User.OwnerID);

            ViewBag.Lots = _db.Lots
                .Select(item => new SelectListItem {Value = item.ID.ToString(), Text = item.LotNumber}).ToList();

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

        //POST Edit
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(string id)
        {
            OwnerVM.User = _db.ApplicationUsers.SingleOrDefault(m => m.Id == OwnerVM.User.Id);

            if (ModelState.IsValid)
            {
                string webRootPath = _hostingEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                var ownerFromDb = _db.Owners
                    .Include(m => m.Address)
                    .Include(m => m.Lots)
                    .FirstOrDefault(m => m.ID == OwnerVM.User.OwnerID);

                if (files.Count > 0 && files[0] != null)
                {
                    var uploads = Path.Combine(webRootPath, @"images\OwnerImage");
                    var extension_new = Path.GetExtension(files[0].FileName);
                    var extension_old = Path.GetExtension(ownerFromDb.Image);

                    if (System.IO.File.Exists(Path.Combine(uploads, OwnerVM.Owner.ID + extension_old)))
                    {
                        System.IO.File.Delete(Path.Combine(uploads, OwnerVM.Owner.ID + extension_old));
                    }
                    using (var filestream = new FileStream(Path.Combine(uploads, OwnerVM.Owner.ID + extension_new), FileMode.Create))
                    {
                        files[0].CopyTo(filestream);
                    }
                    OwnerVM.Owner.Image = @"\" + @"images\OwnerImage" + @"\" + OwnerVM.Owner.ID + extension_new;
                }

                if (OwnerVM.Owner.Image != null)
                {
                    ownerFromDb.Image = OwnerVM.Owner.Image;
                }

                ownerFromDb.FirstName = OwnerVM.Owner.FirstName;
                ownerFromDb.LastName = OwnerVM.Owner.LastName;
                ownerFromDb.IsPrimary = OwnerVM.Owner.IsPrimary;
                ownerFromDb.Occupation = OwnerVM.Owner.Occupation;
                ownerFromDb.Phone = OwnerVM.Owner.Phone;
                ownerFromDb.Birthday = OwnerVM.Owner.Birthday;
                ownerFromDb.EmergencyContactName = OwnerVM.Owner.EmergencyContactName;
                ownerFromDb.EmergencyContactPhone = OwnerVM.Owner.EmergencyContactPhone;
                ownerFromDb.Lots = _db.Lots.Where(lot => OwnerVM.SelectedLots.Contains(lot.ID)).ToList();

                Address address = ownerFromDb.Address;
                address.City = OwnerVM.Owner.Address.City;
                address.State = OwnerVM.Owner.Address.State;
                address.StreetAddress = OwnerVM.Owner.Address.StreetAddress;
                address.Zip = OwnerVM.Owner.Address.Zip;

                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(OwnerVM);
        }

        //GET Details
        public async Task<IActionResult> Details(string id)
        {
            OwnerVM.User = _db.ApplicationUsers.SingleOrDefault(m => m.Id == id);

            if (id == null)
            {
                return NotFound();
            }

            OwnerVM.Owner = await _db.Owners.SingleOrDefaultAsync(m => m.ID == OwnerVM.User.OwnerID);

            if (OwnerVM.Owner == null)
            {
                return NotFound();
            }

            return View(OwnerVM);
        }

        //GET Delete
        public async Task<IActionResult> Delete(string id)
        {

            OwnerVM.User = _db.ApplicationUsers.SingleOrDefault(m => m.Id == id);

            if (id == null)
            {
                return NotFound();
            }

            OwnerVM.Owner = await _db.Owners.SingleOrDefaultAsync(m => m.ID == OwnerVM.User.OwnerID);

            if (OwnerVM.Owner == null)
            {
                return NotFound();
            }

            return View(OwnerVM);
        }

        //POST Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            OwnerVM.User = _db.ApplicationUsers.SingleOrDefault(m => m.Id == OwnerVM.User.Id);
            string webRootPath = _hostingEnvironment.WebRootPath;
            Owner owner = await _db.Owners.FindAsync(OwnerVM.User.OwnerID);

            if (owner == null)
            {
                return NotFound();
            }
            else
            {
                var uploads = Path.Combine(webRootPath, @"images\OwnerImage");
                var extension = Path.GetExtension(owner.Image);

                if (System.IO.File.Exists(Path.Combine(uploads, owner.ID + extension)))
                {
                    System.IO.File.Delete(Path.Combine(uploads, owner.ID + extension));
                }
                _db.Owners.Remove(owner);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
        }
    }
}