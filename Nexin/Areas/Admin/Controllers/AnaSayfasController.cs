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
    public class AnaSayfasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnaSayfasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AnaSayfas
        public async Task<IActionResult> Index()
        {
              return View(await _context.AnaSayfalar.ToListAsync());
        }

        // GET: Admin/AnaSayfas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AnaSayfalar == null)
            {
                return NotFound();
            }

            var anaSayfa = await _context.AnaSayfalar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anaSayfa == null)
            {
                return NotFound();
            }

            return View(anaSayfa);
        }

        // GET: Admin/AnaSayfas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AnaSayfas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Baslik,BaslikAlti,Title,TitleResim")] AnaSayfa anaSayfa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anaSayfa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anaSayfa);
        }

        // GET: Admin/AnaSayfas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AnaSayfalar == null)
            {
                return NotFound();
            }

            var anaSayfa = await _context.AnaSayfalar.FindAsync(id);
            if (anaSayfa == null)
            {
                return NotFound();
            }
            return View(anaSayfa);
        }

        // POST: Admin/AnaSayfas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Baslik,BaslikAlti,Title,TitleResim")] AnaSayfa anaSayfa)
        {
            if (id != anaSayfa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anaSayfa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnaSayfaExists(anaSayfa.Id))
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
            return View(anaSayfa);
        }

        // GET: Admin/AnaSayfas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AnaSayfalar == null)
            {
                return NotFound();
            }

            var anaSayfa = await _context.AnaSayfalar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anaSayfa == null)
            {
                return NotFound();
            }

            return View(anaSayfa);
        }

        // POST: Admin/AnaSayfas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AnaSayfalar == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AnaSayfalar'  is null.");
            }
            var anaSayfa = await _context.AnaSayfalar.FindAsync(id);
            if (anaSayfa != null)
            {
                _context.AnaSayfalar.Remove(anaSayfa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnaSayfaExists(int id)
        {
          return _context.AnaSayfalar.Any(e => e.Id == id);
        }
    }
}
