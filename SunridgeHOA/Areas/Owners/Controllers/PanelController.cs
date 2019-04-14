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
    [Area("Owners")]
    public class PanelController : Controller
    {
        public readonly ApplicationDbContext _db;
        public readonly HostingEnvironment _hostingEnvironment;
        [BindProperty]
        public OwnerViewModel OwnerVM { get; set; }

        public PanelController(ApplicationDbContext db, HostingEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;

            OwnerVM = new OwnerViewModel()
            {
                Owner = new Owner(),
                Lots = _db.Lots.ToList()
            };
        }

        public async Task<IActionResult> Index()
        {
            OwnerVM.Owner = _db.Owners.Where(d => d.ID == 25).FirstOrDefault();
            var users = _db.ApplicationUsers
                .Include(m => m.Owner);
            return View(OwnerVM);
        }
    }
}