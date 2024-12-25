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
    public class AnaSayfaResimsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnaSayfaResimsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AnaSayfaResims
        public async Task<IActionResult> Index()
        {
              return View(await _context.AnaSayfaResimler.ToListAsync());
        }

        // GET: Admin/AnaSayfaResims/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AnaSayfaResimler == null)
            {
                return NotFound();
            }

            var anaSayfaResim = await _context.AnaSayfaResimler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anaSayfaResim == null)
            {
                return NotFound();
            }

            return View(anaSayfaResim);
        }

        // GET: Admin/AnaSayfaResims/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AnaSayfaResims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Resim,Yazi,Yazi2,YaziAktifPasif")] AnaSayfaResim anaSayfaResim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anaSayfaResim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anaSayfaResim);
        }

        // GET: Admin/AnaSayfaResims/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AnaSayfaResimler == null)
            {
                return NotFound();
            }

            var anaSayfaResim = await _context.AnaSayfaResimler.FindAsync(id);
            if (anaSayfaResim == null)
            {
                return NotFound();
            }
            return View(anaSayfaResim);
        }

        // POST: Admin/AnaSayfaResims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Resim,Yazi,Yazi2,YaziAktifPasif")] AnaSayfaResim anaSayfaResim)
        {
            if (id != anaSayfaResim.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anaSayfaResim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnaSayfaResimExists(anaSayfaResim.Id))
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
            return View(anaSayfaResim);
        }

        // GET: Admin/AnaSayfaResims/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AnaSayfaResimler == null)
            {
                return NotFound();
            }

            var anaSayfaResim = await _context.AnaSayfaResimler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anaSayfaResim == null)
            {
                return NotFound();
            }

            return View(anaSayfaResim);
        }

        // POST: Admin/AnaSayfaResims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AnaSayfaResimler == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AnaSayfaResimler'  is null.");
            }
            var anaSayfaResim = await _context.AnaSayfaResimler.FindAsync(id);
            if (anaSayfaResim != null)
            {
                _context.AnaSayfaResimler.Remove(anaSayfaResim);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnaSayfaResimExists(int id)
        {
          return _context.AnaSayfaResimler.Any(e => e.Id == id);
        }
    }
}
