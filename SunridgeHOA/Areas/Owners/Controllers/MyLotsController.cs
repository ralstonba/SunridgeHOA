using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SunridgeHOA.Data;
using SunridgeHOA.Models.ViewModels;

namespace SunridgeHOA.Areas.Owners.Controllers
{
    [Area("Owners")]
    public class MyLotsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        [BindProperty]
        public MyLotsViewModel viewModel { get; set; }

        public MyLotsController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            viewModel.OwnerID = _db.ApplicationUsers.Include(m => m.Owner)
                .FirstOrDefault(m => m.Id.Equals(_userManager.GetUserId(HttpContext.User))).Owner.ID;
            viewModel.Lots = _db.Lots.Where(m => m.OwnerID == viewModel.OwnerID).ToList();

            return View(viewModel);
        }
    }
}