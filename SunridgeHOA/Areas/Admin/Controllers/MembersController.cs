using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SunridgeHOA.Data;
using SunridgeHOA.Models.ViewModels;

namespace SunridgeHOA.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class MembersController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly HostingEnvironment _hostingEnvironment;
        [BindProperty]
        public BoardMembersViewModel BoardMembersVM { get; set; }

        public MembersController(ApplicationDbContext db, HostingEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;

            BoardMembersVM = new BoardMembersViewModel()
            {
                BoardMember = new Models.BoardMember(),
                Owner = _db.Owners.Where(d => d.IsBoardMember == true)
            };
        }
        public async Task<IActionResult> Index()
        {
            var boardMembers = _db.BoardMembers.Include(mbox => mbox.Owner);
            return View(await boardMembers.ToListAsync());
        }

        //GET Create Action Method
        public IActionResult Create()
        {
            return View(BoardMembersVM);
        }
    }
}