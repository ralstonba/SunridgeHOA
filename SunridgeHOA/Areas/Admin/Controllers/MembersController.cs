using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    // [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class MembersController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly HostingEnvironment _hostingEnvironment;
        private readonly UserManager<IdentityUser> _userManager;
        [BindProperty]
        public BoardMembersViewModel BoardMembersVM { get; set; }

        public MembersController(ApplicationDbContext db, HostingEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;

            BoardMembersVM = new BoardMembersViewModel()
            {
                BoardMember = new Models.BoardMember(),
                Users = _db.ApplicationUsers.Where(d => d.Owner.IsBoardMember == false).ToList(),
                Owners = _db.Owners.Where(d => d.IsBoardMember == false).ToList()
            };
        }
        public async Task<IActionResult> Index()
        {
            var boardMembers = _db.BoardMembers.Include(m => m.Owner);
            return View(await boardMembers.ToListAsync());
        }

        //GET Boardmember Create
        public IActionResult Create()
        {
            return View(BoardMembersVM);
        }

        //POST Boardmember Create
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST()
        {
            if (!ModelState.IsValid)
            {
                return View(BoardMembersVM.BoardMember.Owner);
            }

            var appUser = _db.ApplicationUsers
                .Include(m => m.Owner).FirstOrDefault(m => m.OwnerID == BoardMembersVM.BoardMember.OwnerID);
            var owner = appUser.Owner;

            BoardMember newBoardMember = new BoardMember()
            {
                Position = BoardMembersVM.BoardMember.Position,
                Owner = owner,
                OwnerID = owner.ID
            };

            _db.BoardMembers.Add(newBoardMember);
            await _db.SaveChangesAsync();

            if (owner != null)
            {
                owner.IsBoardMember = true;
                _db.Owners.Update(owner);
                _db.SaveChanges();
            }

            await _userManager.AddToRoleAsync(appUser, StaticDetails.AdminEndUser);
           
            return RedirectToAction(nameof(Index));
        }

        //GET Edit
        public async Task<IActionResult> Edit (int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            BoardMembersVM.BoardMember = await _db.BoardMembers.SingleOrDefaultAsync(m => m.ID == id);

            if(BoardMembersVM.BoardMember == null)
            {
                return NotFound();
            }

            return View(BoardMembersVM);
        }

        //POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            if (ModelState.IsValid)
            {
                var ownerFromDb = _db.BoardMembers.Where(m => m.ID == id).FirstOrDefault();
                ownerFromDb.Position = BoardMembersVM.BoardMember.Position;
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(BoardMembersVM);
        }

        //GET Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BoardMembersVM.BoardMember = await _db.BoardMembers.Include(m => m.Owner).SingleOrDefaultAsync(m => m.ID == id);

            if (BoardMembersVM.BoardMember == null)
            {
                return NotFound();
            }

            return View(BoardMembersVM);
        }

        //GET Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BoardMembersVM.BoardMember = await _db.BoardMembers.Include(m => m.Owner).SingleOrDefaultAsync(m => m.ID == id);

            if (BoardMembersVM.BoardMember == null)
            {
                return NotFound();
            }

            return View(BoardMembersVM);
        }

        //POST Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            BoardMember boardMember = _db.BoardMembers.Include(m => m.Owner).FirstOrDefault(m => m.ID == id);
            Owner owner = boardMember.Owner;

            if (boardMember == null)
            {
                return NotFound();
            }
            else
            {
                owner.IsBoardMember = false;

                _db.BoardMembers.Remove(boardMember);
                _db.Owners.Update(owner);

                await _db.SaveChangesAsync();

                ApplicationUser user = _db.ApplicationUsers.Include(m => m.Owner)
                    .FirstOrDefault(m => m.Owner.ID == owner.ID);

                await _userManager.RemoveFromRoleAsync(user, StaticDetails.AdminEndUser);

                return RedirectToAction(nameof(Index));
            }
        }
    }
}
