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

    public class UstBarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UstBarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.ustBars.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ustBar = await _context.ustBars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ustBar == null)
            {
                return NotFound();
            }

            return View(ustBar);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Top,baglanacakUrl,ustAd")] UstBar ustBar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ustBar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ustBar);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ustBar = await _context.ustBars.FindAsync(id);
            if (ustBar == null)
            {
                return NotFound();
            }
            return View(ustBar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Top,baglanacakUrl,ustAd")] UstBar ustBar)
        {
            if (id != ustBar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ustBar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UstBarExists(ustBar.Id))
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
            return View(ustBar);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ustBar = await _context.ustBars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ustBar == null)
            {
                return NotFound();
            }

            return View(ustBar);
        }

        // POST: Admin/UstBars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ustBar = await _context.ustBars.FindAsync(id);
            _context.ustBars.Remove(ustBar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UstBarExists(int id)
        {
            return _context.ustBars.Any(e => e.Id == id);
        }
    }
}
