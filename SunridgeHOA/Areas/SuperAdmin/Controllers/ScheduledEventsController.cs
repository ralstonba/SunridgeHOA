﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SunridgeHOA.Data;
using SunridgeHOA.Models;
using SunridgeHOA.Utility;

namespace SunridgeHOA.Areas.SuperAdmin.Controllers
{
    [Authorize(Roles = StaticData.SuperAdminEndUser)]
    [Area("SuperAdmin")]
    public class ScheduledEventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScheduledEventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SuperAdmin/ScheduledEvents
        public async Task<IActionResult> Index()
        {
            return View(await _context.ScheduledEvents.ToListAsync());
        }

        // GET: SuperAdmin/ScheduledEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduledEvent = await _context.ScheduledEvents
                .FirstOrDefaultAsync(m => m.ID == id);
            if (scheduledEvent == null)
            {
                return NotFound();
            }

            return View(scheduledEvent);
        }

        // GET: SuperAdmin/ScheduledEvents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SuperAdmin/ScheduledEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Subject,Description,Start,End,IsFullDay")] ScheduledEvent scheduledEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scheduledEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(scheduledEvent);
        }

        // GET: SuperAdmin/ScheduledEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduledEvent = await _context.ScheduledEvents.FindAsync(id);
            if (scheduledEvent == null)
            {
                return NotFound();
            }
            return View(scheduledEvent);
        }

        // POST: SuperAdmin/ScheduledEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Subject,Description,Start,End,IsFullDay")] ScheduledEvent scheduledEvent)
        {
            if (id != scheduledEvent.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scheduledEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduledEventExists(scheduledEvent.ID))
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
            return View(scheduledEvent);
        }

        // GET: SuperAdmin/ScheduledEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduledEvent = await _context.ScheduledEvents
                .FirstOrDefaultAsync(m => m.ID == id);
            if (scheduledEvent == null)
            {
                return NotFound();
            }

            return View(scheduledEvent);
        }

        // POST: SuperAdmin/ScheduledEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var scheduledEvent = await _context.ScheduledEvents.FindAsync(id);
            _context.ScheduledEvents.Remove(scheduledEvent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduledEventExists(int id)
        {
            return _context.ScheduledEvents.Any(e => e.ID == id);
        }
    }
}
