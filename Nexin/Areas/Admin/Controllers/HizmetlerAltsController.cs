using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nexin.Data;
using Nexin.Entity;

namespace Nexin.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HizmetlerAltsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HizmetlerAltsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/HizmetlerAlts
        public async Task<IActionResult> Index()
        {
              return View(await _context.HizmetlerAlts.ToListAsync());
        }

        // GET: Admin/HizmetlerAlts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HizmetlerAlts == null)
            {
                return NotFound();
            }

            var hizmetlerAlt = await _context.HizmetlerAlts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hizmetlerAlt == null)
            {
                return NotFound();
            }

            return View(hizmetlerAlt);
        }

        // GET: Admin/HizmetlerAlts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/HizmetlerAlts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,URL")] HizmetlerAlt hizmetlerAlt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hizmetlerAlt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hizmetlerAlt);
        }

        // GET: Admin/HizmetlerAlts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HizmetlerAlts == null)
            {
                return NotFound();
            }

            var hizmetlerAlt = await _context.HizmetlerAlts.FindAsync(id);
            if (hizmetlerAlt == null)
            {
                return NotFound();
            }
            return View(hizmetlerAlt);
        }

        // POST: Admin/HizmetlerAlts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,URL")] HizmetlerAlt hizmetlerAlt)
        {
            if (id != hizmetlerAlt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hizmetlerAlt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HizmetlerAltExists(hizmetlerAlt.Id))
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
            return View(hizmetlerAlt);
        }

        // GET: Admin/HizmetlerAlts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HizmetlerAlts == null)
            {
                return NotFound();
            }

            var hizmetlerAlt = await _context.HizmetlerAlts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hizmetlerAlt == null)
            {
                return NotFound();
            }

            return View(hizmetlerAlt);
        }

        // POST: Admin/HizmetlerAlts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HizmetlerAlts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.HizmetlerAlts'  is null.");
            }
            var hizmetlerAlt = await _context.HizmetlerAlts.FindAsync(id);
            if (hizmetlerAlt != null)
            {
                _context.HizmetlerAlts.Remove(hizmetlerAlt);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HizmetlerAltExists(int id)
        {
          return _context.HizmetlerAlts.Any(e => e.Id == id);
        }
    }
}
