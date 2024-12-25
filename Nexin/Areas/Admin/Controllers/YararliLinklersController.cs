using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nexin.Data;
using Nexin.Entity;

namespace Nexin.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class YararliLinklersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public YararliLinklersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/YararliLinklers
        public async Task<IActionResult> Index()
        {
            return View(await _context.YararliLinklers.ToListAsync());
        }

        // GET: Admin/YararliLinklers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yararliLinkler = await _context.YararliLinklers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yararliLinkler == null)
            {
                return NotFound();
            }

            return View(yararliLinkler);
        }

        // GET: Admin/YararliLinklers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/YararliLinklers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,URL")] YararliLinkler yararliLinkler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yararliLinkler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yararliLinkler);
        }

        // GET: Admin/YararliLinklers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yararliLinkler = await _context.YararliLinklers.FindAsync(id);
            if (yararliLinkler == null)
            {
                return NotFound();
            }
            return View(yararliLinkler);
        }

        // POST: Admin/YararliLinklers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,URL")] YararliLinkler yararliLinkler)
        {
            if (id != yararliLinkler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yararliLinkler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YararliLinklerExists(yararliLinkler.Id))
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
            return View(yararliLinkler);
        }

        // GET: Admin/YararliLinklers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yararliLinkler = await _context.YararliLinklers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yararliLinkler == null)
            {
                return NotFound();
            }

            return View(yararliLinkler);
        }

        // POST: Admin/YararliLinklers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yararliLinkler = await _context.YararliLinklers.FindAsync(id);
            _context.YararliLinklers.Remove(yararliLinkler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YararliLinklerExists(int id)
        {
            return _context.YararliLinklers.Any(e => e.Id == id);
        }
    }
}
