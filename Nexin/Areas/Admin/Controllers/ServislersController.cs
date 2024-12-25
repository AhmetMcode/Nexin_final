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
using Nexin.Data.Migrations;
using Nexin.Entity;

namespace Nexin.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ServislersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment env;

        public ServislersController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Servisler.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servisler = await _context.Servisler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servisler == null)
            {
                return NotFound();
            }

            return View(servisler);
        }

        // GET: Admin/Servislers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Servisler servisler, IFormFile resim, IFormFile icon)
        {
            if (resim != null)
            {
                // Resim dosyasının kaydedileceği dizin
                string uzanti = Path.GetExtension(resim.FileName);
                string dosyaAd = Guid.NewGuid() + uzanti;
                string kaydetmeYolu = Path.Combine(env.WebRootPath, "img", dosyaAd);
                using (var stream = System.IO.File.Create(kaydetmeYolu))
                {
                    resim.CopyTo(stream);
                }

                // Kaydedilen dosya yolunu veritabanına eklemek
                servisler.Resim = dosyaAd;
            }
            if (icon != null)
            {
                string uzanti = Path.GetExtension(icon.FileName);
                string dosyaAd = Guid.NewGuid() + uzanti;
                string kaydetmeYolu = Path.Combine(env.WebRootPath, "img", dosyaAd);
                using (var stream = System.IO.File.Create(kaydetmeYolu))
                {
                    resim.CopyTo(stream);
                }

                // Kaydedilen dosya yolunu veritabanına eklemek
                servisler.Icon = dosyaAd;
            }
            _context.Add(servisler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servisler = await _context.Servisler.FindAsync(id);
            if (servisler == null)
            {
                return NotFound();
            }
            return View(servisler);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Servisler servisler, IFormFile resim, IFormFile icon)
        {
            var eskiResim = _context.Servisler.Where(x => x.Id == servisler.Id).FirstOrDefault();
            eskiResim.KucukYazi = servisler.KucukYazi;
            eskiResim.Baslik = servisler.Baslik;
            eskiResim.UzunYazi = servisler.UzunYazi;
            eskiResim.Icon = servisler.Icon;
            eskiResim.MetaTaglar = servisler.MetaTaglar;
            if (resim != null)
            {
                string uzanti = Path.GetExtension(resim.FileName);
                string dosyaAd = Guid.NewGuid() + uzanti;
                string kaydetmeYolu = Path.Combine(env.WebRootPath, "img", dosyaAd);
                using (var stream = System.IO.File.Create(kaydetmeYolu))
                {
                    resim.CopyTo(stream);
                }

                eskiResim.Resim = dosyaAd;
            }
            if (icon != null)
            {
                string uzanti = Path.GetExtension(icon.FileName);
                string dosyaAd = Guid.NewGuid() + uzanti;
                string kaydetmeYolu = Path.Combine(env.WebRootPath, "img", dosyaAd);
                using (var stream = System.IO.File.Create(kaydetmeYolu))
                {
                    resim.CopyTo(stream);
                }

                // Kaydedilen dosya yolunu veritabanına eklemek
                eskiResim.Icon = dosyaAd;
            }
            _context.Update(eskiResim);
            await _context.SaveChangesAsync();

            return View(servisler);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servisler = await _context.Servisler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servisler == null)
            {
                return NotFound();
            }

            return View(servisler);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servisler = await _context.Servisler.FindAsync(id);
            _context.Servisler.Remove(servisler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServislerExists(int id)
        {
            return _context.Servisler.Any(e => e.Id == id);
        }
    }
}
