﻿using System;
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

namespace SunridgeHOA.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FormsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly HostingEnvironment _hostingEnvironment;

        public FormsController(ApplicationDbContext db, HostingEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var forms = _db.ApplicationUsers.Include(m => m.Owner.Form);
            return View(await forms.ToListAsync());
        }

        public IActionResult FormList()
        {
            return View();
        }

        public IActionResult ComplaintFormCreate()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> ComplaintFormCreate()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }

        //      _db.Add();

        //    db.User = _db.ApplicationUsers.SingleOrDefault(m => m.Id == OwnerVM.User.Id);

        //    OwnerVM.User.Owner = OwnerVM.Owner;
        //    await _db.SaveChangesAsync();
        //}

        public IActionResult ComplaintFormEdit(string id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ComplaintFormEditPost(string id){
            return View();
        }

        public IActionResult ComplaintFormDetails(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View();

        }

        public IActionResult ComplaintFormDelete()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ComplaintFormDeleteConfirmed(string id)
        {
            return View();
        }


    }
}