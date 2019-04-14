using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SunridgeHOA.Data;
using SunridgeHOA.Models;
using SunridgeHOA.Models.ViewModels;
using SunridgeHOA.Utilities;

namespace SunridgeHOA.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly HostingEnvironment _hostingEnvironment;
        private readonly UserManager<IdentityUser> _userManager;
        
        private string WebRootPath { get; set; }
        [BindProperty]
        public ClassifiedViewModel ClassifiedVM { get; set; } 
        public AccountController(ApplicationDbContext db, HostingEnvironment hostingEnvironment, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
            _userManager = userManager;
            WebRootPath = hostingEnvironment.WebRootPath;
            ClassifiedVM = new ClassifiedViewModel()
            {
                Lots = new Models.ClassifiedListing(),
                Cabins = new Models.ClassifiedListing()
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
                return RedirectToAction("Lots", "Home", new { area = "Public" });
            }

            // This can fail if you do not ensure that the method requires the user to be logged in in the first place

            ApplicationUser applicationUser = _db.ApplicationUsers.Include(m => m.Owner)
                .FirstOrDefault(m => m.Id.Equals(_userManager.GetUserId(HttpContext.User)));

            // You need to check that applicationUser is actually and owner

            ClassifiedListing classifiedListing = new ClassifiedListing()
            {
                ClassifiedCategory = _db.ClassifiedCategories.FirstOrDefault(m => m.Name == "Lots"),
                Owner = applicationUser.Owner,
                Name = ClassifiedVM.Lots.Name,
                Description = ClassifiedVM.Lots.Description,
                Price = ClassifiedVM.Lots.Price,
                Email = ClassifiedVM.Lots.Email,
                PhoneNumber = ClassifiedVM.Lots.PhoneNumber,
                ListingDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            };

            _db.ClassifiedListings.Add(classifiedListing);
            await _db.SaveChangesAsync();

            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            Directory.CreateDirectory(Path.Combine(webRootPath, @"img\Lots", classifiedListing.ID.ToString()));
            string imgFolder = Path.Combine(@"img\Lots", classifiedListing.ID.ToString());


            var lotsFromDb = _db.ClassifiedListings.Find(classifiedListing.ID);

            if (files.Count != 0)
            {
                //Image/s have been uploaded with form
                var uploads = Path.Combine(webRootPath, imgFolder);
                var extension = Path.GetExtension(files[0].FileName);

                for (int i = 0; i < files.Count; i++)
                {
                    var extensions = Path.GetExtension(files[i].FileName);
                    using (var filestream = new FileStream(Path.Combine(uploads, classifiedListing.ID + "." + i + extensions), FileMode.Create))
                    {
                        files[i].CopyTo(filestream); //moves to server and renames
                    }
                }

                //now I know the new image name, so I can save the string image to the database
                lotsFromDb.Image = @"\" + imgFolder + @"\" + classifiedListing.ID + ".0" + extension;
            }
            else
            {
                //user didn't give us an image so we'll upload the placeholder
                var uploads = Path.Combine(webRootPath, imgFolder, @"land-icon-01.svg");
                System.IO.File.Copy(uploads, webRootPath + @"\" + imgFolder + @"\" + classifiedListing.ID + ".jpg");
                lotsFromDb.Image = @"\" + imgFolder + @"\" + classifiedListing.ID + ".jpg";
            }

            await _db.SaveChangesAsync();
            return RedirectToAction("Lots", "Home", new { area = "Public" });
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
                string imgFolder = @"img\Lots";

                var productFromDb = _db.ClassifiedListings.Where(m => m.ID == id).FirstOrDefault();

                if (files.Count > 0 && files[0] != null)
                {
                    //if user uploads a new image
                    var uploads = Path.Combine(webRootPath, imgFolder);
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
                    ClassifiedVM.Lots.Image = @"\" + imgFolder + @"\" + ClassifiedVM.Lots.ID + extension_new;
                }

                if (ClassifiedVM.Lots.Image != null)
                {
                    productFromDb.Image = ClassifiedVM.Lots.Image;
                }

                productFromDb.Name = ClassifiedVM.Lots.Name;
                productFromDb.Price = ClassifiedVM.Lots.Price;
                productFromDb.Description = ClassifiedVM.Lots.Description;
                productFromDb.PhoneNumber = ClassifiedVM.Lots.PhoneNumber;
                productFromDb.Email = ClassifiedVM.Lots.Email;
                productFromDb.LastModifiedDate = DateTime.Now;

                await _db.SaveChangesAsync();

                return RedirectToAction("Lots","Home", new { area = "Public" });
            }

            return View(ClassifiedVM);
        }

        public async Task<IActionResult> LotDetails(int? id)
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

        public async Task<IActionResult> DeleteLot(int? id)
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

        //POST : Delete
        [HttpPost, ActionName("DeleteLot")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteLotConfirmed(int id)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            string imgFolder = @"img\Lots";
            ClassifiedListing lots = await _db.ClassifiedListings.FindAsync(id);

            if (lots == null)
            {
                return NotFound();
            }
            else
            {
                var uploads = Path.Combine(webRootPath, imgFolder);
                var extension = Path.GetExtension(lots.Image);

                if (System.IO.File.Exists(Path.Combine(uploads, lots.ID + extension)))
                {
                    System.IO.File.Delete(Path.Combine(uploads, lots.ID + extension));
                }

                _db.ClassifiedListings.Remove(lots);
                await _db.SaveChangesAsync();

                return RedirectToAction("Lots", "Home", new { area = "Public" });
            }
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

            // This can fail if you do not ensure that the method requires the user to be logged in in the first place

            ApplicationUser applicationUser = _db.ApplicationUsers.Include(m => m.Owner)
                .FirstOrDefault(m => m.Id.Equals(_userManager.GetUserId(HttpContext.User)));

            // You need to check that applicationUser is actually and owner

            ClassifiedListing classifiedListing = new ClassifiedListing()
            {
                ClassifiedCategory = _db.ClassifiedCategories.FirstOrDefault(m => m.Name == "Cabins"),
                Owner = applicationUser.Owner,
                Name = ClassifiedVM.Cabins.Name,
                Description = ClassifiedVM.Cabins.Description,
                Price = ClassifiedVM.Cabins.Price,
                Email = ClassifiedVM.Cabins.Email,
                PhoneNumber = ClassifiedVM.Cabins.PhoneNumber,
                ListingDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            };

            _db.ClassifiedListings.Add(classifiedListing);
            await _db.SaveChangesAsync();

            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            Directory.CreateDirectory(Path.Combine(webRootPath, @"img\Cabins", classifiedListing.ID.ToString()));
            string imgFolder = Path.Combine(@"img\Cabins", classifiedListing.ID.ToString());


            var CabinsFromDb = _db.ClassifiedListings.Find(classifiedListing.ID);

            if (files.Count != 0)
            {
                //Image/s have been uploaded with form
                var uploads = Path.Combine(webRootPath, imgFolder);
                var extension = Path.GetExtension(files[0].FileName);

                for (int i = 0; i < files.Count; i++)
                {
                    var extensions = Path.GetExtension(files[i].FileName);
                    using (var filestream = new FileStream(Path.Combine(uploads, classifiedListing.ID + "." + i + extensions), FileMode.Create))
                    {
                        files[i].CopyTo(filestream); //moves to server and renames
                    }
                }

                //now I know the new image name, so I can save the string image to the database
                CabinsFromDb.Image = @"\" + imgFolder + @"\" + classifiedListing.ID + ".0" + extension;
            }
            else
            {
                //user didn't give us an image so we'll upload the placeholder
                var uploads = Path.Combine(webRootPath, imgFolder, @"land-icon-01.svg");
                System.IO.File.Copy(uploads, webRootPath + @"\" + imgFolder + @"\" + classifiedListing.ID + ".jpg");
                CabinsFromDb.Image = @"\" + imgFolder + @"\" + classifiedListing.ID + ".jpg";
            }

            await _db.SaveChangesAsync();
            return RedirectToAction("Cabins", "Home", new { area = "Public" });
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
                string imgFolder = @"img\Cabins";
                var files = HttpContext.Request.Form.Files;

                var productFromDb = _db.ClassifiedListings.Where(m => m.ID == id).FirstOrDefault();

                if (files.Count > 0 && files[0] != null)
                {
                    //if user uploads a new image
                    var uploads = Path.Combine(webRootPath, imgFolder);
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
                    ClassifiedVM.Lots.Image = @"\" + imgFolder + @"\" + ClassifiedVM.Cabins.ID + extension_new;
                }

                if (ClassifiedVM.Lots.Image != null)
                {
                    productFromDb.Image = ClassifiedVM.Cabins.Image;
                }

                productFromDb.Name = ClassifiedVM.Cabins.Name;
                productFromDb.Price = ClassifiedVM.Cabins.Price;
                productFromDb.Description = ClassifiedVM.Cabins.Description;
                productFromDb.PhoneNumber = ClassifiedVM.Cabins.PhoneNumber;
                productFromDb.Email = ClassifiedVM.Cabins.Email;
                productFromDb.LastModifiedDate = DateTime.Now;
                await _db.SaveChangesAsync();

                return RedirectToAction("Cabins", "Home", new { area = "Public" });
            }

            return View(ClassifiedVM);
        }

        public async Task<IActionResult> CabinDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClassifiedVM.Cabins = await _db.ClassifiedListings.SingleOrDefaultAsync(m => m.ID == id);

            if (ClassifiedVM.Lots == null)
            {
                NotFound();
            }

            return View(ClassifiedVM);
        }

        public async Task<IActionResult> DeleteCabin(int? id)
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

        //POST : Delete
        [HttpPost, ActionName("DeleteCabin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCabinConfirmed(int id)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            string imgFolder = @"img\Cabins";
            ClassifiedListing cabins = await _db.ClassifiedListings.FindAsync(id);

            if (cabins == null)
            {
                return NotFound();
            }
            else
            {
                var uploads = Path.Combine(webRootPath, imgFolder);
                var extension = Path.GetExtension(cabins.Image);

                if (System.IO.File.Exists(Path.Combine(uploads, cabins.ID + extension)))
                {
                    System.IO.File.Delete(Path.Combine(uploads, cabins.ID + extension));
                }

                _db.ClassifiedListings.Remove(cabins);
                await _db.SaveChangesAsync();

                return RedirectToAction("Cabins", "Home", new { area = "Public" });
            }
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
                return RedirectToAction("OtherServices", "Home", new { area = "Public" });
            }

            Service serviceFile = new Service()
            {
                FilePath = HttpContext.Request.Form.Files[0].FileName
            };

            _db.Services.Add(serviceFile);
            await _db.SaveChangesAsync();

            var files = HttpContext.Request.Form.Files;
            
            if (files.Count != 0)
            {
                var uploads = Path.Combine(WebRootPath, @"img\other-services");
                var extension = Path.GetExtension(files[0].FileName);
                using (var filestream = new FileStream(Path.Combine(uploads, serviceFile.ID + extension), FileMode.Create))
                {
                    files[0].CopyTo(filestream);
                }

                var productFromDb = _db.Services.Where(m => m.ID == serviceFile.ID).FirstOrDefault();
                productFromDb.FilePath = Path.Combine(uploads, serviceFile.ID + extension);
                await _db.SaveChangesAsync();
            }

            await _db.SaveChangesAsync();
            return RedirectToAction("OtherServices", "Home", new { area = "Public" });
        }
    }
}