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
    [Area("OWners")]
    public class KeyHistoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KeyHistoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/KeyHistories
        public async Task<IActionResult> Index()
        {
            return View(await _context.KeyHistories.ToListAsync());
        }

        // GET: Admin/KeyHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keyHistory = await _context.KeyHistories
                .FirstOrDefaultAsync(m => m.ID == id);
            if (keyHistory == null)
            {
                return NotFound();
            }

            return View(keyHistory);
        }

        // GET: Admin/KeyHistories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/KeyHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Status,DateIssued,DateReturned,PaidAmount,IsArchive,LastModifiedDate")] KeyHistory keyHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(keyHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(keyHistory);
        }

        // GET: Admin/KeyHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keyHistory = await _context.KeyHistories.FindAsync(id);
            if (keyHistory == null)
            {
                return NotFound();
            }
            return View(keyHistory);
        }

        // POST: Admin/KeyHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Status,DateIssued,DateReturned,PaidAmount,IsArchive,LastModifiedDate")] KeyHistory keyHistory)
        {
            if (id != keyHistory.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(keyHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KeyHistoryExists(keyHistory.ID))
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
            return View(keyHistory);
        }

        // GET: Admin/KeyHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keyHistory = await _context.KeyHistories
                .FirstOrDefaultAsync(m => m.ID == id);
            if (keyHistory == null)
            {
                return NotFound();
            }

            return View(keyHistory);
        }

        // POST: Admin/KeyHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var keyHistory = await _context.KeyHistories.FindAsync(id);
            _context.KeyHistories.Remove(keyHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KeyHistoryExists(int id)
        {
            return _context.KeyHistories.Any(e => e.ID == id);
        }
    }
}
