using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nexin.Data;
using Nexin.Entity;
using Nexin.Models;

namespace Nexin.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class AnaSayfaSeciton3Controller : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment env;

        public AnaSayfaSeciton3Controller(ApplicationDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.AnaSayfaSeciton3.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anaSayfaSeciton3 = await _context.AnaSayfaSeciton3
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anaSayfaSeciton3 == null)
            {
                return NotFound();
            }

            return View(anaSayfaSeciton3);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( AnaSayfaSeciton3 anaSayfaSeciton3)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anaSayfaSeciton3);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anaSayfaSeciton3);
        }

        // GET: Admin/AnaSayfaSeciton3/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AnaSayfaSeciton3 vm = _context.AnaSayfaSeciton3.Where(x => x.Id == id).FirstOrDefault();
            AnaSayfaSection3Edit eklenecek = new AnaSayfaSection3Edit();
            eklenecek.Baslik = vm.Baslik;
            eklenecek.AltYazi = vm.AltYazi;
            eklenecek.Icerik1 = vm.Icerik1;
            eklenecek.Icerik2 = vm.Icerik2;
            eklenecek.Icerik3 = vm.Icerik3;
            eklenecek.Icerik4 = vm.Icerik4;
            eklenecek.Icerik5 = vm.Icerik5;
            eklenecek.Icerik6 = vm.Icerik6;

            return View(eklenecek);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AnaSayfaSection3Edit vm)
        {
            AnaSayfaSeciton3 eklenecek = _context.AnaSayfaSeciton3.Where(x => x.Id == id).FirstOrDefault();

            eklenecek.Baslik = vm.Baslik;
            eklenecek.AltYazi = vm.AltYazi;
            eklenecek.Icerik1 = vm.Icerik1;
            eklenecek.Icerik2 = vm.Icerik2;
            eklenecek.Icerik3 = vm.Icerik3;
            eklenecek.Icerik4 = vm.Icerik4;
            eklenecek.Icerik5 = vm.Icerik5;
            eklenecek.Icerik6 = vm.Icerik6;
            if (vm.ResimSol != null)
            {
                string uzanti = Path.GetExtension(vm.ResimSol.FileName);
                string dosyaAd = Guid.NewGuid() + uzanti;
                string kaydetmeYolu = Path.Combine(env.WebRootPath, "img", dosyaAd);
                using (var stream = System.IO.File.Create(kaydetmeYolu))
                {
                    vm.ResimSol.CopyTo(stream);
                }
                eklenecek.ResimSol = dosyaAd;
            }
            if (vm.ResimOynar != null)
            {
                string uzanti = Path.GetExtension(vm.ResimOynar.FileName);
                string dosyaAd = Guid.NewGuid() + uzanti;
                string kaydetmeYolu = Path.Combine(env.WebRootPath, "img", dosyaAd);
                using (var stream = System.IO.File.Create(kaydetmeYolu))
                {
                    vm.ResimOynar.CopyTo(stream);
                }
                eklenecek.ResimOynar = dosyaAd;
            }
            _context.AnaSayfaSeciton3.Update(eklenecek);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Admin/AnaSayfaSeciton3/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anaSayfaSeciton3 = await _context.AnaSayfaSeciton3
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anaSayfaSeciton3 == null)
            {
                return NotFound();
            }

            return View(anaSayfaSeciton3);
        }

        // POST: Admin/AnaSayfaSeciton3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anaSayfaSeciton3 = await _context.AnaSayfaSeciton3.FindAsync(id);
            _context.AnaSayfaSeciton3.Remove(anaSayfaSeciton3);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnaSayfaSeciton3Exists(int id)
        {
            return _context.AnaSayfaSeciton3.Any(e => e.Id == id);
        }
    }
}
