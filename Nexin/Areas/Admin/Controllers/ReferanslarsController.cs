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

    public class ReferanslarsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment env;

        public ReferanslarsController(ApplicationDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        // GET: Admin/Referanslars
        public async Task<IActionResult> Index()
        {
            return View(await _context.Referanslars.ToListAsync());
        }

        // GET: Admin/Referanslars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referanslar = await _context.Referanslars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (referanslar == null)
            {
                return NotFound();
            }

            return View(referanslar);
        }

        // GET: Admin/Referanslars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Referanslars/Create
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
                Referanslar anaSayfaHakkindaResimler = new Referanslar();
                anaSayfaHakkindaResimler.ResimYolu = dosyaAd;
                _context.Referanslars.Add(anaSayfaHakkindaResimler);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Referanslars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referanslar = await _context.Referanslars.FindAsync(id);
            if (referanslar == null)
            {
                return NotFound();
            }
            return View(referanslar);
        }

        // POST: Admin/Referanslars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ResimYolu")] Referanslar referanslar)
        {
            if (id != referanslar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(referanslar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReferanslarExists(referanslar.Id))
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
            return View(referanslar);
        }

        // GET: Admin/Referanslars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referanslar = await _context.Referanslars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (referanslar == null)
            {
                return NotFound();
            }

            return View(referanslar);
        }

        // POST: Admin/Referanslars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var referanslar = await _context.Referanslars.FindAsync(id);
            _context.Referanslars.Remove(referanslar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReferanslarExists(int id)
        {
            return _context.Referanslars.Any(e => e.Id == id);
        }
    }
}
