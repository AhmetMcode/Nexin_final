using Microsoft.AspNetCore.Mvc;
using Nexin.Data;
using Nexin.Models;
using System.Linq;

namespace Nexin.Controllers
{
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext db;

        public BlogController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var result = db.Blogs.ToList();
            return View(result);
        }
        public IActionResult Bloglar(string id)
        {
            var blog = db.Blogs.FirstOrDefault(x=>x.Url == id);
            BlogVM vm = new BlogVM();
            vm.Blog = blog;
            vm.Bloglar = db.Blogs.ToList();
            return View(vm);
        }
    }
}
