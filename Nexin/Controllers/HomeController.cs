using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nexin.Data;
using Nexin.Entity;
using Nexin.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Nexin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger , ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();  
            homeViewModel.AnaSayfaHakkindaResimler = _context.AnaSayfaHakkindaResimlers.ToList();
            homeViewModel.Hizmets = _context.Hizmet.ToList();
            homeViewModel.HakkimizdaAnaSayfa = _context.HakkimizdaAnaSayfa.FirstOrDefault();
            homeViewModel.Referanslar = _context.Referanslars.ToList();
            homeViewModel.Ortaklar = _context.Ortaklar.ToList();
            homeViewModel.Bloglar = _context.Blogs.Take(4).ToList();
            homeViewModel.AnaSayfaTamamlanmis = _context.AnaSayfaTamamlanmis.FirstOrDefault();
            homeViewModel.AnaSayfaSeciton3 = _context.AnaSayfaSeciton3.FirstOrDefault();
            homeViewModel.Servisler = _context.Servisler.Take(6).ToList();
            return View(homeViewModel);
        }

        public async Task<IActionResult> TumHizmetler()
        {
            var hizmetler = await _context.Hizmet.ToListAsync();
            return View(hizmetler);
        }

        public async Task<IActionResult> Hizmetler(string id)
        {
            var proje = _context.Hizmet.Where(x => x.Url == id).FirstOrDefault();
            var hepsi = await _context.Hizmet
                        .Select(x => new HizmetListesiViewModel { Ad = x.Ad, Url = x.Url })
                        .Take(5)
                        .ToListAsync();
            ViewBag.Hizmet = hepsi;
            return View(proje);
        }
        public IActionResult sss()
        {
            var sss = _context.SSS.ToList();
            return View(sss);
        }
        public IActionResult TumSurecler()
        {
            var servisler = _context.Servisler.ToList(); // Tüm servisleri getir
            return View(servisler); // View'e gönder
        }


        public IActionResult Iletisim()
        {
            AddMessageViewModel vm = new AddMessageViewModel();
            vm.LayoutAyar = _context.LayoutAyars.FirstOrDefault();
            return View(vm);
        }

        [HttpPost]
        public IActionResult MesajGonder([FromForm] AddMessageViewModel vm)
        {
            if (ModelState.IsValid)
            {
                // Yeni bir Iletisim nesnesi oluştur ve veritabanına kaydet
                Iletisim iletisim = new Iletisim
                {
                    Isim = vm.Isim,
                    Mail = vm.Mail,
                    TelNo = vm.TelNo,
                    Konu = vm.Konu,
                    Mesaj = vm.Mesaj
                };

                _context.Add(iletisim);
                _context.SaveChanges();

                // Başarılı yanıt gönder
                return Json(new { success = true, message = "Mesaj başarıyla gönderildi!" });
            }

            // Hata yanıtı gönder
            return Json(new { success = false, message = "Geçersiz form verisi." });
        }


        public List<UstBar> UstBarList()
        {
            List<UstBar> ustBars = _context.ustBars.ToList(); // UstBar verilerini çekin
            return ustBars;
        }
        public List<YararliLinkler> YaraliLinkler()
        {
            List<YararliLinkler> ustBars = _context.YararliLinklers.ToList(); // UstBar verilerini çekin
            return ustBars;
        }
        public List<HizmetlerAlt> HizmetlerAlt()
        {
            List<HizmetlerAlt> ustBars = _context.HizmetlerAlts.ToList(); // UstBar verilerini çekin
            return ustBars;
        }
        public string Renk()
        {
            string ustBars = _context.LayoutAyars.FirstOrDefault()?.Renk; // UstBar verilerini çekin
            return ustBars;
        }
        public string Logo()
        {
            string ustBars = _context.LayoutAyars.FirstOrDefault()?.Logo; // UstBar verilerini çekin
            return ustBars;
        }
        public string BeyazLogo()
        {
            string ustBars = _context.LayoutAyars.FirstOrDefault()?.BeyazLogo; // UstBar verilerini çekin
            return ustBars;
        }
        public string Instagram()
        {
            string ustBars = _context.LayoutAyars.FirstOrDefault()?.InstagramLink; // UstBar verilerini çekin
            return ustBars;
        }
        public string Slogan()
        {
            string ustBars = _context.LayoutAyars.FirstOrDefault()?.Slogan; // UstBar verilerini çekin
            return ustBars;
        }
        public string Face()
        {
            string ustBars = _context.LayoutAyars.FirstOrDefault()?.FaceLink; // UstBar verilerini çekin
            return ustBars;
        }
        public string Mail()
        {
            string ustBars = _context.LayoutAyars.FirstOrDefault()?.Mail; // UstBar verilerini çekin
            return ustBars;
        }
        public string Telefon()
        {
            string ustBars = _context.LayoutAyars.FirstOrDefault()?.Telefon; // UstBar verilerini çekin
            return ustBars;
        }
        public string Linked()
        {
            string ustBars = _context.LayoutAyars.FirstOrDefault()?.LinkedLink; // UstBar verilerini çekin
            return ustBars;
        }
        public string adres()
        {
            string ustBars = _context.LayoutAyars.FirstOrDefault()?.Adres; // UstBar verilerini çekin
            return ustBars;
        }
        public string UstYazi()
        {
            string ustBars = _context.AnaSayfalar.FirstOrDefault()?.Baslik; // UstBar verilerini çekin
            return ustBars;
        }
        public string UstYaziAlti()
        {
            string ustBars = _context.AnaSayfalar.FirstOrDefault()?.BaslikAlti; // UstBar verilerini çekin
            return ustBars;
        }
        public string Title()
        {
            string ustBars = _context.AnaSayfalar.FirstOrDefault()?.Title; // UstBar verilerini çekin
            return ustBars;
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    public class HizmetListesiViewModel
    {
        public string Ad { get; set; }
        public string Url { get; set; }
    }

}
