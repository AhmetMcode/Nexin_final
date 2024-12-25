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

    public class SSSesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SSSesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/SSSes
        public async Task<IActionResult> Index()
        {
            return View(await _context.SSS.ToListAsync());
        }

        // GET: Admin/SSSes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sSS = await _context.SSS
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sSS == null)
            {
                return NotFound();
            }

            return View(sSS);
        }

        // GET: Admin/SSSes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/SSSes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Baslik,Icerik")] SSS sSS)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sSS);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sSS);
        }

        // GET: Admin/SSSes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sSS = await _context.SSS.FindAsync(id);
            if (sSS == null)
            {
                return NotFound();
            }
            return View(sSS);
        }

        // POST: Admin/SSSes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Baslik,Icerik")] SSS sSS)
        {
            if (id != sSS.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sSS);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SSSExists(sSS.Id))
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
            return View(sSS);
        }

        // GET: Admin/SSSes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sSS = await _context.SSS
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sSS == null)
            {
                return NotFound();
            }

            return View(sSS);
        }

        // POST: Admin/SSSes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sSS = await _context.SSS.FindAsync(id);
            _context.SSS.Remove(sSS);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SSSExists(int id)
        {
            return _context.SSS.Any(e => e.Id == id);
        }
    }
}
