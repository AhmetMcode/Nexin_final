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

    public class HakkindaResimlersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment env;

        public HakkindaResimlersController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        // GET: Admin/HakkindaResimlers
        public async Task<IActionResult> Index()
        {
            return View(await _context.AnaSayfaHakkindaResimlers.ToListAsync());
        }

        // GET: Admin/HakkindaResimlers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anaSayfaHakkindaResimler = await _context.AnaSayfaHakkindaResimlers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anaSayfaHakkindaResimler == null)
            {
                return NotFound();
            }

            return View(anaSayfaHakkindaResimler);
        }

        // GET: Admin/HakkindaResimlers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/HakkindaResimlers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile Resim)
        {
            if (Resim != null)
            {
                string uzanti = Path.GetExtension(Resim.FileName);
                string dosyaAd = Guid.NewGuid() + uzanti;
                string kaydetmeYolu = Path.Combine(env.WebRootPath, "img", dosyaAd);
                using (var stream = System.IO.File.Create(kaydetmeYolu))
                {
                    Resim.CopyTo(stream);
                }
                AnaSayfaHakkindaResimler anaSayfaHakkindaResimler = new AnaSayfaHakkindaResimler();
                anaSayfaHakkindaResimler.Resim = dosyaAd;
                _context.AnaSayfaHakkindaResimlers.Add(anaSayfaHakkindaResimler);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/HakkindaResimlers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anaSayfaHakkindaResimler = await _context.AnaSayfaHakkindaResimlers.FindAsync(id);
            if (anaSayfaHakkindaResimler == null)
            {
                return NotFound();
            }
            return View(anaSayfaHakkindaResimler);
        }

        // POST: Admin/HakkindaResimlers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Resim")] AnaSayfaHakkindaResimler anaSayfaHakkindaResimler)
        {
            if (id != anaSayfaHakkindaResimler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anaSayfaHakkindaResimler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnaSayfaHakkindaResimlerExists(anaSayfaHakkindaResimler.Id))
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
            return View(anaSayfaHakkindaResimler);
        }

        // GET: Admin/HakkindaResimlers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anaSayfaHakkindaResimler = await _context.AnaSayfaHakkindaResimlers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anaSayfaHakkindaResimler == null)
            {
                return NotFound();
            }

            return View(anaSayfaHakkindaResimler);
        }

        // POST: Admin/HakkindaResimlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anaSayfaHakkindaResimler = await _context.AnaSayfaHakkindaResimlers.FindAsync(id);
            _context.AnaSayfaHakkindaResimlers.Remove(anaSayfaHakkindaResimler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnaSayfaHakkindaResimlerExists(int id)
        {
            return _context.AnaSayfaHakkindaResimlers.Any(e => e.Id == id);
        }
    }
}
