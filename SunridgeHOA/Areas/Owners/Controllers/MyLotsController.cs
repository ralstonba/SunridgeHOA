using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SunridgeHOA.Data;
using SunridgeHOA.Models;
using SunridgeHOA.Models.ViewModels;
using SunridgeHOA.Utilities;

namespace SunridgeHOA.Areas.Owners.Controllers
{
    [Authorize(Roles = StaticDetails.OwnerEndUser)]
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

            viewModel = new MyLotsViewModel();
        }

        public IActionResult Index()
        {
            viewModel.Owner = _db.ApplicationUsers.Include(m => m.Owner)
                .FirstOrDefault(m => m.Id.Equals(_userManager.GetUserId(HttpContext.User))).Owner;

            var owner = _db.Owners.Include(m => m.Lots).ThenInclude(m => m.Address)
                .FirstOrDefault(m => m.ID == viewModel.Owner.ID);

            viewModel.Lots = owner.Lots;

            return View(viewModel);
        }
    }
}