using Microsoft.AspNetCore.Mvc;
using Nexin.Data;
using System.Linq;

namespace Nexin.Controllers
{
    public class NexinController : Controller
    {
        private readonly ApplicationDbContext db;

        public NexinController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Morfo(string id)
        {
            var dosya = db.Sayfa.Where(x =>x.Url == id).FirstOrDefault();
            return View(dosya);
        }
    }
}
