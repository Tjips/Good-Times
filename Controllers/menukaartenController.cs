using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoodTimes.Data;
using GoodTimes.Models;

namespace GoodTimes.Controllers
{
    public class menukaartenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public menukaartenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: menukaarten
        public async Task<IActionResult> Index()
        {
            return View(await _context.menukaart.ToListAsync());
        }

        // GET: menukaarten/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menukaart = await _context.menukaart
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menukaart == null)
            {
                return NotFound();
            }

            return View(menukaart);
        }

        // GET: menukaarten/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: menukaarten/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naam")] menukaart menukaart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menukaart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(menukaart);
        }

        // GET: menukaarten/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menukaart = await _context.menukaart.FindAsync(id);
            if (menukaart == null)
            {
                return NotFound();
            }
            return View(menukaart);
        }

        // POST: menukaarten/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naam")] menukaart menukaart)
        {
            if (id != menukaart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menukaart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!menukaartExists(menukaart.Id))
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
            return View(menukaart);
        }

        // GET: menukaarten/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menukaart = await _context.menukaart
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menukaart == null)
            {
                return NotFound();
            }

            return View(menukaart);
        }

        // POST: menukaarten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menukaart = await _context.menukaart.FindAsync(id);
            _context.menukaart.Remove(menukaart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool menukaartExists(int id)
        {
            return _context.menukaart.Any(e => e.Id == id);
        }
    }
}
