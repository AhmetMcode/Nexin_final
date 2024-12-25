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

    public class HakkimizdaAnaSayfaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HakkimizdaAnaSayfaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.HakkimizdaAnaSayfa.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hakkimizdaAnaSayfa = await _context.HakkimizdaAnaSayfa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hakkimizdaAnaSayfa == null)
            {
                return NotFound();
            }

            return View(hakkimizdaAnaSayfa);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( HakkimizdaAnaSayfa hakkimizdaAnaSayfa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hakkimizdaAnaSayfa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hakkimizdaAnaSayfa);
        }

        // GET: Admin/HakkimizdaAnaSayfa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hakkimizdaAnaSayfa = await _context.HakkimizdaAnaSayfa.FindAsync(id);
            if (hakkimizdaAnaSayfa == null)
            {
                return NotFound();
            }
            return View(hakkimizdaAnaSayfa);
        }

        // POST: Admin/HakkimizdaAnaSayfa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, HakkimizdaAnaSayfa hakkimizdaAnaSayfa)
        {
            if (id != hakkimizdaAnaSayfa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hakkimizdaAnaSayfa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HakkimizdaAnaSayfaExists(hakkimizdaAnaSayfa.Id))
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
            return View(hakkimizdaAnaSayfa);
        }

        // GET: Admin/HakkimizdaAnaSayfa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hakkimizdaAnaSayfa = await _context.HakkimizdaAnaSayfa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hakkimizdaAnaSayfa == null)
            {
                return NotFound();
            }

            return View(hakkimizdaAnaSayfa);
        }

        // POST: Admin/HakkimizdaAnaSayfa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hakkimizdaAnaSayfa = await _context.HakkimizdaAnaSayfa.FindAsync(id);
            _context.HakkimizdaAnaSayfa.Remove(hakkimizdaAnaSayfa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HakkimizdaAnaSayfaExists(int id)
        {
            return _context.HakkimizdaAnaSayfa.Any(e => e.Id == id);
        }
    }
}
