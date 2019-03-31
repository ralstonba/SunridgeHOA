using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SunridgeHOA.Data;
using SunridgeHOA.Models.ViewModels;

namespace SunridgeHOA.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly HostingEnvironment _hostingEnvironment;
        
        private string WebRootPath { get; set; }
        [BindProperty]
        public ClassifiedViewModel ClassifiedVM { get; set; } 
        public AccountController(ApplicationDbContext db, HostingEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
            WebRootPath = hostingEnvironment.WebRootPath;
            ClassifiedVM = new ClassifiedViewModel()
            {
                Lots = new Models.ClassifiedListing()
            };
        }
        public IActionResult AddLot()
        {
            return View(ClassifiedVM);
        }

        [HttpPost, ActionName("CreateLot")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateLot()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Lots", "Home");
            }

            _db.ClassifiedListings.Add(ClassifiedVM.Lots);
            await _db.SaveChangesAsync();
            return RedirectToAction("Lots", "Home");
        }

        public async Task<IActionResult> EditLot(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClassifiedVM.Lots = await _db.ClassifiedListings.SingleOrDefaultAsync(m => m.ID == id);

            if (ClassifiedVM.Lots == null)
            {
                NotFound();
            }

            return View(ClassifiedVM);
        }

        //Post : Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditLot(int id)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostingEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                var productFromDb = _db.ClassifiedListings.Where(m => m.ID == ClassifiedVM.Lots.ID).FirstOrDefault();

                if (files.Count > 0 && files[0] != null)
                {
                    //if user uploads a new image
                    var uploads = Path.Combine(webRootPath, @"img\otherservices");
                    var extension_new = Path.GetExtension(files[0].FileName);
                    var extension_old = Path.GetExtension(uploads + ClassifiedVM.Lots.ID);

                    if (System.IO.File.Exists(Path.Combine(uploads, ClassifiedVM.Lots.ID + extension_old)))
                    {
                        System.IO.File.Delete(Path.Combine(uploads, ClassifiedVM.Lots.ID + extension_old));
                    }
                    using (var filestream = new FileStream(Path.Combine(uploads, ClassifiedVM.Lots.ID + extension_new), FileMode.Create))
                    {
                        files[0].CopyTo(filestream);
                    }
                    //ClassifiedVM.Lots.Image = @"\" + SD.ImageFolder + @"\" + ProductsVM.Products.Id + extension_new;
                }

                //if (ClassifiedVM.Lots.Image != null)
                //{
                //    productFromDb.Image = ProductsVM.Products.Image;
                //}

                productFromDb.Name = ClassifiedVM.Lots.Name;
                productFromDb.Price = ClassifiedVM.Lots.Price;
                productFromDb.Description = ClassifiedVM.Lots.Description;
                productFromDb.PhoneNumber = ClassifiedVM.Lots.PhoneNumber;
                productFromDb.Email = ClassifiedVM.Lots.Email;
                await _db.SaveChangesAsync();

                return RedirectToAction("Lots","Home");
            }

            return View(ClassifiedVM);
        }

        public IActionResult AddCabin()
        {
            return View(ClassifiedVM);
        }

        [HttpPost, ActionName("CreateCabin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCabin()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Cabin", "Home");
            }

            _db.ClassifiedListings.Add(ClassifiedVM.Cabins);
            await _db.SaveChangesAsync();
            return RedirectToAction("Cabins", "Home");
        }

        public async Task<IActionResult> EditCabin(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClassifiedVM.Cabins = await _db.ClassifiedListings.SingleOrDefaultAsync(m => m.ID == id);

            if (ClassifiedVM.Cabins == null)
            {
                NotFound();
            }

            return View(ClassifiedVM);
        }

        //Post : Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCabin(int id)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostingEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                var productFromDb = _db.ClassifiedListings.Where(m => m.ID == ClassifiedVM.Cabins.ID).FirstOrDefault();

                if (files.Count > 0 && files[0] != null)
                {
                    //if user uploads a new image
                    var uploads = Path.Combine(webRootPath, @"img\otherservices");
                    var extension_new = Path.GetExtension(files[0].FileName);
                    var extension_old = Path.GetExtension(uploads + ClassifiedVM.Cabins.ID);

                    if (System.IO.File.Exists(Path.Combine(uploads, ClassifiedVM.Cabins.ID + extension_old)))
                    {
                        System.IO.File.Delete(Path.Combine(uploads, ClassifiedVM.Cabins.ID + extension_old));
                    }
                    using (var filestream = new FileStream(Path.Combine(uploads, ClassifiedVM.Cabins.ID + extension_new), FileMode.Create))
                    {
                        files[0].CopyTo(filestream);
                    }
                    //ClassifiedVM.Lots.Image = @"\" + SD.ImageFolder + @"\" + ProductsVM.Products.Id + extension_new;
                }

                //if (ClassifiedVM.Lots.Image != null)
                //{
                //    productFromDb.Image = ProductsVM.Products.Image;
                //}

                productFromDb.Name = ClassifiedVM.Cabins.Name;
                productFromDb.Price = ClassifiedVM.Cabins.Price;
                productFromDb.Description = ClassifiedVM.Cabins.Description;
                productFromDb.PhoneNumber = ClassifiedVM.Cabins.PhoneNumber;
                productFromDb.Email = ClassifiedVM.Cabins.Email;
                await _db.SaveChangesAsync();

                return RedirectToAction("Cabins", "Home");
            }

            return View(ClassifiedVM);
        }

        public IActionResult AddService()
        {
            return View(ClassifiedVM);
        }

        [HttpPost, ActionName("CreateService")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddServicePOST()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("OtherServices", "Home");
            }
            _db.Files.Add(ClassifiedVM.File);
            await _db.SaveChangesAsync();

            var files = HttpContext.Request.Form.Files;
            
            if (files.Count != 0)
            {
                var uploads = Path.Combine(WebRootPath, @"img\otherservices");
                var extension = Path.GetExtension(files[0].FileName);
                using (var filestream = new FileStream(Path.Combine(uploads, ClassifiedVM.File.ID + extension), FileMode.Create))
                {
                    files[0].CopyTo(filestream);
                } 
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("OtherServices", "Home");
        }
    }
}