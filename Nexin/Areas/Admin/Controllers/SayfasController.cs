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

    public class SayfasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SayfasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Sayfas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sayfa.ToListAsync());
        }

        // GET: Admin/Sayfas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sayfa = await _context.Sayfa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sayfa == null)
            {
                return NotFound();
            }

            return View(sayfa);
        }

        // GET: Admin/Sayfas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Sayfas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Sayfa sayfa)
        {
                _context.Add(sayfa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Sayfas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sayfa = await _context.Sayfa.FindAsync(id);
            if (sayfa == null)
            {
                return NotFound();
            }
            return View(sayfa);
        }

        // POST: Admin/Sayfas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Url,Icerik")] Sayfa sayfa)
        {
            if (id != sayfa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sayfa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SayfaExists(sayfa.Id))
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
            return View(sayfa);
        }

        // GET: Admin/Sayfas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sayfa = await _context.Sayfa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sayfa == null)
            {
                return NotFound();
            }

            return View(sayfa);
        }

        // POST: Admin/Sayfas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sayfa = await _context.Sayfa.FindAsync(id);
            _context.Sayfa.Remove(sayfa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SayfaExists(int id)
        {
            return _context.Sayfa.Any(e => e.Id == id);
        }
    }
}
