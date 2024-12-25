using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nexin.Data;
using Nexin.Entity;

namespace Nexin.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class OrtaklarController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment env;

        public OrtaklarController(ApplicationDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        // GET: Admin/Ortaklar
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ortaklar.ToListAsync());
        }

        // GET: Admin/Ortaklar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ortaklar = await _context.Ortaklar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ortaklar == null)
            {
                return NotFound();
            }

            return View(ortaklar);
        }

        // GET: Admin/Ortaklar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Ortaklar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile ResimYolu)
        {
            if (ResimYolu != null)
            {
                string uzanti = Path.GetExtension(ResimYolu.FileName);
                string dosyaAd = Guid.NewGuid() + uzanti;
                string kaydetmeYolu = Path.Combine(env.WebRootPath, "img", dosyaAd);
                using (var stream = System.IO.File.Create(kaydetmeYolu))
                {
                    ResimYolu.CopyTo(stream);
                }
                Ortaklar OrtaklarResimler = new Ortaklar();
                OrtaklarResimler.ResimYolu = dosyaAd;
                _context.Ortaklar.Add(OrtaklarResimler);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Ortaklar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Ortaklar = await _context.Ortaklar.FindAsync(id);
            if (Ortaklar == null)
            {
                return NotFound();
            }
            return View(Ortaklar);
        }

        // POST: Admin/Ortaklar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ResimYolu")] Ortaklar ortaklar)
        {
            if (id != ortaklar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ortaklar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrtaklarExists(ortaklar.Id))
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
            return View(ortaklar);
        }

        // GET: Admin/Ortaklar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ortaklar = await _context.Ortaklar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ortaklar == null)
            {
                return NotFound();
            }

            return View(ortaklar);
        }

        // POST: Admin/Ortaklar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ortaklar = await _context.Ortaklar.FindAsync(id);
            _context.Ortaklar.Remove(ortaklar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrtaklarExists(int id)
        {
            return _context.Ortaklar.Any(e => e.Id == id);
        }
    }
}
