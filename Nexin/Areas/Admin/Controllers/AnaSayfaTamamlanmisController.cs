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

    public class AnaSayfaTamamlanmisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnaSayfaTamamlanmisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AnaSayfaTamamlanmis
        public async Task<IActionResult> Index()
        {
            return View(await _context.AnaSayfaTamamlanmis.ToListAsync());
        }

        // GET: Admin/AnaSayfaTamamlanmis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anaSayfaTamamlanmis = await _context.AnaSayfaTamamlanmis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anaSayfaTamamlanmis == null)
            {
                return NotFound();
            }

            return View(anaSayfaTamamlanmis);
        }

        // GET: Admin/AnaSayfaTamamlanmis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AnaSayfaTamamlanmis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( AnaSayfaTamamlanmis anaSayfaTamamlanmis)
        {
                _context.AnaSayfaTamamlanmis.Add(anaSayfaTamamlanmis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        // GET: Admin/AnaSayfaTamamlanmis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anaSayfaTamamlanmis = await _context.AnaSayfaTamamlanmis.FindAsync(id);
            if (anaSayfaTamamlanmis == null)
            {
                return NotFound();
            }
            return View(anaSayfaTamamlanmis);
        }

        // POST: Admin/AnaSayfaTamamlanmis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Yazisi,ic1,sayi1,ic2,sayi2,ic3,sayi3")] AnaSayfaTamamlanmis anaSayfaTamamlanmis)
        {
            if (id != anaSayfaTamamlanmis.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anaSayfaTamamlanmis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnaSayfaTamamlanmisExists(anaSayfaTamamlanmis.Id))
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
            return View(anaSayfaTamamlanmis);
        }

        // GET: Admin/AnaSayfaTamamlanmis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anaSayfaTamamlanmis = await _context.AnaSayfaTamamlanmis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anaSayfaTamamlanmis == null)
            {
                return NotFound();
            }

            return View(anaSayfaTamamlanmis);
        }

        // POST: Admin/AnaSayfaTamamlanmis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anaSayfaTamamlanmis = await _context.AnaSayfaTamamlanmis.FindAsync(id);
            _context.AnaSayfaTamamlanmis.Remove(anaSayfaTamamlanmis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnaSayfaTamamlanmisExists(int id)
        {
            return _context.AnaSayfaTamamlanmis.Any(e => e.Id == id);
        }
    }
}
