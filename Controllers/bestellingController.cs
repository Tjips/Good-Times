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
    public class bestellingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public bestellingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: bestelling
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.bestelling.Include(p => p.Products);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: bestelling/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bestelling = await _context.bestelling
                .Include(p => p.Products)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bestelling == null)
            {
                return NotFound();
            }

            return View(bestelling);
        }

        // GET: bestelling/Create
        public async Task<IActionResult> CreateAsync()

        {
            var products = await _context.product.Where(b => b.categorieId == Id).ToListAsync();
            ViewBag.products = products;

            return View();
        }

        // POST: bestelling/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Gerecht,Aantal,Tafel,Tijd,Opmerking,Acties")] bestelling bestelling)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bestelling);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bestelling);
        }

        // GET: bestelling/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bestelling = await _context.bestelling.FindAsync(id);
            if (bestelling == null)
            {
                return NotFound();
            }
            return View(bestelling);
        }

        // POST: bestelling/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Gerecht,Aantal,Tafel,Tijd,Opmerking,Acties")] bestelling bestelling)
        {
            if (id != bestelling.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bestelling);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!bestellingExists(bestelling.Id))
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
            return View(bestelling);
        }

        // GET: bestelling/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bestelling = await _context.bestelling
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bestelling == null)
            {
                return NotFound();
            }

            return View(bestelling);
        }

        // POST: bestelling/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bestelling = await _context.bestelling.FindAsync(id);
            _context.bestelling.Remove(bestelling);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool bestellingExists(int id)
        {
            return _context.bestelling.Any(e => e.Id == id);
        }
    }
}
