using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SunridgeHOA.Data;
using SunridgeHOA.Models;

namespace SunridgeHOA.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KeysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KeysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Keys
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Keys.Include(k => k.KeyHistory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Keys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var key = await _context.Keys
                .Include(k => k.KeyHistory)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (key == null)
            {
                return NotFound();
            }

            return View(key);
        }

        // GET: Admin/Keys/Create
        public IActionResult Create()
        {
            ViewData["KeyHistoryID"] = new SelectList(_context.KeyHistories, "ID", "ID");
            return View();
        }

        // POST: Admin/Keys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,SerialNumber,IsArchive,LastModifiedDate,KeyHistoryID")] Key key)
        {
            if (ModelState.IsValid)
            {
                _context.Add(key);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KeyHistoryID"] = new SelectList(_context.KeyHistories, "ID", "ID", key.KeyHistoryID);
            return View(key);
        }

        // GET: Admin/Keys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var key = await _context.Keys.FindAsync(id);
            if (key == null)
            {
                return NotFound();
            }
            ViewData["KeyHistoryID"] = new SelectList(_context.KeyHistories, "ID", "ID", key.KeyHistoryID);
            return View(key);
        }

        // POST: Admin/Keys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,SerialNumber,IsArchive,LastModifiedDate,KeyHistoryID")] Key key)
        {
            if (id != key.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(key);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KeyExists(key.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["KeyHistoryID"] = new SelectList(_context.KeyHistories, "ID", "ID", key.KeyHistoryID);
            return View(key);
        }

        // GET: Admin/Keys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var key = await _context.Keys
                .Include(k => k.KeyHistory)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (key == null)
            {
                return NotFound();
            }

            return View(key);
        }

        // POST: Admin/Keys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var key = await _context.Keys.FindAsync(id);
            _context.Keys.Remove(key);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KeyExists(int id)
        {
            return _context.Keys.Any(e => e.ID == id);
        }
    }
}
