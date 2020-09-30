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
    public class bonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public bonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: bon
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.bon.Include(p => p.Tafel);
            return View(await _context.bon.ToListAsync());
        }

        // GET: bon/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bon = await _context.bon
                .Include(p => p.Tafel)
                .FirstOrDefaultAsync(m => m.Id == id);
                
            if (bon == null)
            {
                return NotFound();
            }

            return View(bon);
        }

        // GET: bon/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.bestelling = await _context.bestelling.ToListAsync();

            return View();
        }

        // POST: bon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] bon bon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bon);
        }

        // GET: bon/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bon = await _context.bon.FindAsync(id);
            if (bon == null)
            {
                return NotFound();
            }
            return View(bon);
        }

        // POST: bon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] bon bon)
        {
            if (id != bon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!bonExists(bon.Id))
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
            return View(bon);
        }

        // GET: bon/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bon = await _context.bon
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bon == null)
            {
                return NotFound();
            }

            return View(bon);
        }

        // POST: bon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bon = await _context.bon.FindAsync(id);
            _context.bon.Remove(bon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool bonExists(int id)
        {
            return _context.bon.Any(e => e.Id == id);
        }
    }
}
