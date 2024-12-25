using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.Xml;
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

    public class HizmetController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment env;

        public HizmetController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        // GET: Admin/Hizmet
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hizmet.ToListAsync());
        }

        // GET: Admin/Hizmet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Hizmet = await _context.Hizmet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Hizmet == null)
            {
                return NotFound();
            }

            return View(Hizmet);
        }

        // GET: Admin/Hizmet/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Hizmet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjeEkleViewModel vm)
        {
            Hizmet eklenecek = new Hizmet();

            eklenecek.Ad = vm.Ad;
            eklenecek.AltAd = vm.AltAd;
            eklenecek.MetaTaglar = vm.MetaTaglar;
            eklenecek.Icerik = vm.Icerik;
            eklenecek.Url = vm.Url; 
            if (vm.AnaResim != null)
            {
                string uzanti = Path.GetExtension(vm.AnaResim.FileName);
                string dosyaAd = Guid.NewGuid() + uzanti;
                string kaydetmeYolu = Path.Combine(env.WebRootPath, "img", dosyaAd);
                using (var stream = System.IO.File.Create(kaydetmeYolu))
                {
                    vm.AnaResim.CopyTo(stream);
                }
                eklenecek.AnaResim = dosyaAd;
            }
            if (vm.AnaResim1 != null)
            {
                string uzanti = Path.GetExtension(vm.AnaResim1.FileName);
                string dosyaAd = Guid.NewGuid() + uzanti;
                string kaydetmeYolu = Path.Combine(env.WebRootPath, "img", dosyaAd);
                using (var stream = System.IO.File.Create(kaydetmeYolu))
                {
                    vm.AnaResim1.CopyTo(stream);
                }
                eklenecek.AnaResim1 = dosyaAd;
            }
            if (vm.AnaResim2 != null)
            {
                string uzanti = Path.GetExtension(vm.AnaResim2.FileName);
                string dosyaAd = Guid.NewGuid() + uzanti;
                string kaydetmeYolu = Path.Combine(env.WebRootPath, "img", dosyaAd);
                using (var stream = System.IO.File.Create(kaydetmeYolu))
                {
                    vm.AnaResim2.CopyTo(stream);
                }
                eklenecek.AnaResim2 = dosyaAd;
            }
            if (vm.KapakResimi != null)
            {
                string uzanti = Path.GetExtension(vm.KapakResimi.FileName);
                string dosyaAd = Guid.NewGuid() + uzanti;
                string kaydetmeYolu = Path.Combine(env.WebRootPath, "img", dosyaAd);
                using (var stream = System.IO.File.Create(kaydetmeYolu))
                {
                    vm.KapakResimi.CopyTo(stream);
                }
                eklenecek.KapakResimi = dosyaAd;
            }
            _context.Add(eklenecek);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Hizmet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Hizmet = await _context.Hizmet.FindAsync(id);
            if (Hizmet == null)
            {
                return NotFound();
            }
            ProjeEkleViewModel eklenecek = new ProjeEkleViewModel();
            Hizmet vm = _context.Hizmet.Where(x => x.Id == id).FirstOrDefault();
            eklenecek.Id = vm.Id;

            eklenecek.Ad = vm.Ad;
            eklenecek.AltAd = vm.AltAd;
            eklenecek.Url = vm.Url;
            eklenecek.Icerik = vm.Icerik;
            eklenecek.MetaTaglar = vm.MetaTaglar;
            eklenecek.Url = vm.Url;
            return View(eklenecek);
        }

        // POST: Admin/Hizmet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProjeEkleViewModel vm)
        {


            Hizmet eklenecek = _context.Hizmet.Where(x => x.Id == id).FirstOrDefault();
            eklenecek.Url = vm.Url;

            eklenecek.Ad = vm.Ad;
            eklenecek.AltAd = vm.AltAd;
            eklenecek.Icerik = vm.Icerik;
            eklenecek.Url = vm.Url;
            eklenecek.MetaTaglar = vm.MetaTaglar;
            if (vm.AnaResim != null)
            {
                string uzanti = Path.GetExtension(vm.AnaResim.FileName);
                string dosyaAd = Guid.NewGuid() + uzanti;
                string kaydetmeYolu = Path.Combine(env.WebRootPath, "img", dosyaAd);
                using (var stream = System.IO.File.Create(kaydetmeYolu))
                {
                    vm.AnaResim.CopyTo(stream);
                }
                eklenecek.AnaResim = dosyaAd;
            }
            if (vm.AnaResim1 != null)
            {
                string uzanti = Path.GetExtension(vm.AnaResim1.FileName);
                string dosyaAd = Guid.NewGuid() + uzanti;
                string kaydetmeYolu = Path.Combine(env.WebRootPath, "img", dosyaAd);
                using (var stream = System.IO.File.Create(kaydetmeYolu))
                {
                    vm.AnaResim1.CopyTo(stream);
                }
                eklenecek.AnaResim1 = dosyaAd;
            }
            if (vm.AnaResim2 != null)
            {
                string uzanti = Path.GetExtension(vm.AnaResim2.FileName);
                string dosyaAd = Guid.NewGuid() + uzanti;
                string kaydetmeYolu = Path.Combine(env.WebRootPath, "img", dosyaAd);
                using (var stream = System.IO.File.Create(kaydetmeYolu))
                {
                    vm.AnaResim2.CopyTo(stream);
                }
                eklenecek.AnaResim2 = dosyaAd;
            }
            if (vm.KapakResimi != null)
            {
                string uzanti = Path.GetExtension(vm.KapakResimi.FileName);
                string dosyaAd = Guid.NewGuid() + uzanti;
                string kaydetmeYolu = Path.Combine(env.WebRootPath, "img", dosyaAd);
                using (var stream = System.IO.File.Create(kaydetmeYolu))
                {
                    vm.KapakResimi.CopyTo(stream);
                }
                eklenecek.KapakResimi = dosyaAd;
            }
            _context.Hizmet.Update(eklenecek);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Admin/Hizmet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Hizmet = await _context.Hizmet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Hizmet == null)
            {
                return NotFound();
            }

            return View(Hizmet);
        }

        // POST: Admin/Hizmet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Hizmet = await _context.Hizmet.FindAsync(id);
            _context.Hizmet.Remove(Hizmet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HizmetExists(int id)
        {
            return _context.Hizmet.Any(e => e.Id == id);
        }
    }
}
