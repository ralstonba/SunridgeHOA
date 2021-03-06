﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SunridgeHOA.Data;
using SunridgeHOA.Models;
using SunridgeHOA.Models.ViewModels;

namespace SunridgeHOA.Controllers
{
    [Area("Public")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ApplicationDbContext _db;

        public string WebRootPath { get; set; }

        public HomeController(ApplicationDbContext context, ApplicationDbContext db, HostingEnvironment hostingEnvironment)
        {
            _context = context;
            _db = db;
            WebRootPath = hostingEnvironment.WebRootPath;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.Banner.ToListAsync());
        }

        public async Task<IActionResult> BoardMembers()
        {
            List<BoardMemberIndexVM> bmList = _context.BoardMembers.Include(m => m.Owner)
                .Join(_context.ApplicationUsers, member => member.Owner.ID, user => user.Owner.ID,
                    (member, user) => new BoardMemberIndexVM(member, user)).ToList();

            return View(bmList);
        }

        public IActionResult EventCalender()
        {
            return View();
        }

        public async Task<IActionResult> Lots()
        {
            ApplicationUser temp = _context.ApplicationUsers.FirstOrDefault(m => m.UserName == User.Identity.Name);
            if (temp != null)
            {
                ViewData["OwnerID"] = temp.OwnerID;
            }
            return View(await _context.ClassifiedListings.Where(m => m.ClassifiedCategory.Name == "Lots").ToListAsync());
        }

        public async Task<IActionResult> PublicLots(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClassifiedViewModel ClassifiedVM = new ClassifiedViewModel();

            ClassifiedVM.Lots = await _db.ClassifiedListings.SingleOrDefaultAsync(m => m.ID == id);

            if (ClassifiedVM.Lots == null)
            {
                NotFound();
            }

            ViewBag.Images = Directory.EnumerateFiles(Path.Combine(WebRootPath, @"img/Lots", ClassifiedVM.Lots.ID.ToString()))
                .Select(fn => Path.Combine(WebRootPath, @"img/Lots", ClassifiedVM.Lots.ID.ToString()) + Path.GetFileName(fn));

            return View(ClassifiedVM);
        }

        public async Task<IActionResult> Cabins()
        {
            ApplicationUser temp = _context.ApplicationUsers.FirstOrDefault(m => m.UserName == User.Identity.Name);
            if (temp != null)
            {
                ViewData["OwnerID"] = temp.OwnerID;
            }
            return View(await _context.ClassifiedListings.Where(m => m.ClassifiedCategory.Name == "Cabins").ToListAsync());
        }

        public async Task<IActionResult> PublicCabins(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClassifiedViewModel ClassifiedVM = new ClassifiedViewModel();

            ClassifiedVM.Cabins = await _db.ClassifiedListings.SingleOrDefaultAsync(m => m.ID == id);

            if (ClassifiedVM.Lots == null)
            {
                NotFound();
            }

            ViewBag.Images = Directory.EnumerateFiles(Path.Combine(WebRootPath, @"img/Cabins", ClassifiedVM.Cabins.ID.ToString()))
                .Select(fn => Path.Combine(WebRootPath, @"img/Cabins", ClassifiedVM.Cabins.ID.ToString()) + Path.GetFileName(fn));

            return View(ClassifiedVM);
        }

        public IActionResult OtherServices()
        {
            return View();
        }

        public IActionResult Rules()
        {
            return View();
        }

        public IActionResult Maps()
        {
            return View();
        }

        public IActionResult Forms()
        {
            return View();
        }

        public IActionResult FireInfo()
        {
            return View();
        }

        public IActionResult Season2018()
        {
            return View();
        }

        public IActionResult Season2017()
        {
            return View();
        }

        public IActionResult Season2016()
        {
            return View();
        }

        public IActionResult PhotoGallery()
        {
            return View();
        }

        public IActionResult SummerGallery()
        {
            return View();
        }

        public IActionResult WinterGallery()
        {
            return View();
        }

        public IActionResult PeopleGallery()
        {
            return View();
        }

        public IActionResult H13()
        {
            return View();
        }

        public IActionResult CabinBak()
        {
            return View();
        }

        public IActionResult CreateAccount()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, ActionName("Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginPOST()
        {
            return RedirectToAction("Index", "account");
        }

        [HttpPost, ActionName("CreateAccount")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAccountPOST()
        {
            return RedirectToAction("Index", "account");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
