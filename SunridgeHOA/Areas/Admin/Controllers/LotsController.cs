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
    public class LotsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LotsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Lots
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Lots.Include(l => l.Address);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Lots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lot = await _context.Lots
                .Include(l => l.Address)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lot == null)
            {
                return NotFound();
            }

            return View(lot);
        }

        // GET: Admin/Lots/Create
        public IActionResult Create()
        {
            ViewData["AddressID"] = new SelectList(_context.Addresses, "ID", "ID");
            return View();
        }

        // POST: Admin/Lots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LotNumber,Status,IsArchive,LastModifiedDate,TaxID,InventoryID,AddressID")] Lot lot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressID"] = new SelectList(_context.Addresses, "ID", "ID", lot.AddressID);
            return View(lot);
        }

        // GET: Admin/Lots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lot = await _context.Lots.FindAsync(id);
            if (lot == null)
            {
                return NotFound();
            }
            ViewData["AddressID"] = new SelectList(_context.Addresses, "ID", "ID", lot.AddressID);
            return View(lot);
        }

        // POST: Admin/Lots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,LotNumber,Status,IsArchive,LastModifiedDate,TaxID,InventoryID,AddressID")] Lot lot)
        {
            if (id != lot.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LotExists(lot.ID))
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
            ViewData["AddressID"] = new SelectList(_context.Addresses, "ID", "ID", lot.AddressID);
            return View(lot);
        }

        // GET: Admin/Lots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lot = await _context.Lots
                .Include(l => l.Address)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lot == null)
            {
                return NotFound();
            }

            return View(lot);
        }

        // POST: Admin/Lots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lot = await _context.Lots.FindAsync(id);
            _context.Lots.Remove(lot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LotExists(int id)
        {
            return _context.Lots.Any(e => e.ID == id);
        }
    }
}
