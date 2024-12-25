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

    public class LayoutAyarsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public LayoutAyarsController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Admin/LayoutAyars
        public async Task<IActionResult> Index()
        {
            var asd = await _context.LayoutAyars.ToListAsync();
            return View(asd);
        }

        // GET: Admin/LayoutAyars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var layoutAyar = await _context.LayoutAyars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (layoutAyar == null)
            {
                return NotFound();
            }

            return View(layoutAyar);
        }

        // GET: Admin/LayoutAyars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/LayoutAyars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(LayoutViewModel vm)
        {


            LayoutAyar layoutAyar = new LayoutAyar();
            layoutAyar.Renk = vm.Renk;
            _context.Add(layoutAyar);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/LayoutAyars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var layar = _context.LayoutAyars.FirstOrDefault();
            LayoutViewModel vm = new LayoutViewModel();
            vm.Renk = layar.Renk;
            vm.LinkedLink = layar.LinkedLink;
            vm.FaceLink = layar.FaceLink;
            vm.InstagramLink = layar.InstagramLink;
            vm.Slogan = layar.Slogan;
            vm.LinkedLink = layar.LinkedLink;
            vm.Telefon = layar.Telefon;
            vm.Mail = layar.Mail;
            vm.Adres = layar.Adres;
            return View(vm);
        }

        // POST: Admin/LayoutAyars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LayoutViewModel vm)
        {
            LayoutAyar layoutAyar = _context.LayoutAyars.FirstOrDefault();
            layoutAyar.Renk = vm.Renk;
            layoutAyar.LinkedLink = vm.LinkedLink;
            layoutAyar.InstagramLink = vm.InstagramLink;
            layoutAyar.Slogan = vm.Slogan;
            layoutAyar.FaceLink = vm.FaceLink;
            layoutAyar.Mail = vm.Mail;
            layoutAyar.Telefon = vm.Telefon;
            layoutAyar.Adres = vm.Adres;
            if (vm.Logo != null)
            {
                string uzanti = Path.GetExtension(vm.Logo.FileName);
                string dosyaAd = Guid.NewGuid() + uzanti;
                string kaydetmeYolu = Path.Combine(_env.WebRootPath, "img", dosyaAd);
                using (var stream = System.IO.File.Create(kaydetmeYolu))
                {
                    vm.Logo.CopyTo(stream);
                }
                layoutAyar.Logo = dosyaAd;
            }
            if (vm.BeyazLogo != null)
            {
                string uzanti = Path.GetExtension(vm.BeyazLogo.FileName);
                string dosyaAd = Guid.NewGuid() + uzanti;
                string kaydetmeYolu = Path.Combine(_env.WebRootPath, "img", dosyaAd);
                using (var stream = System.IO.File.Create(kaydetmeYolu))
                {
                    vm.BeyazLogo.CopyTo(stream);
                }
                layoutAyar.BeyazLogo = dosyaAd;
            }
            _context.Update(layoutAyar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/LayoutAyars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var layoutAyar = await _context.LayoutAyars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (layoutAyar == null)
            {
                return NotFound();
            }

            return View(layoutAyar);
        }

        // POST: Admin/LayoutAyars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var layoutAyar = await _context.LayoutAyars.FindAsync(id);
            _context.LayoutAyars.Remove(layoutAyar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LayoutAyarExists(int id)
        {
            return _context.LayoutAyars.Any(e => e.Id == id);
        }
    }
}
