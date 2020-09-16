using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoodTimes.Data;
using GoodTimes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace GoodTimes.Controllers
{
    [Authorize]
    public class reserveringenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public reserveringenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: reserveringen
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.reservering.Include(r => r.medewerker);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: reserveringen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservering = await _context.reservering
                .Include(r => r.medewerker)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservering == null)
            {
                return NotFound();
            }

            return View(reservering);
        }

        // GET: reserveringen/Create
        public IActionResult Create()
        {
            ViewData["medewerkerId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: reserveringen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,voornaam,achternaam,aantal,email,telefoon,datum,begintijd,eindtijd,aangemaakt,opmerking,medewerkerId")] reservering reservering)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservering);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["medewerkerId"] = new SelectList(_context.Users, "Id", "Id", reservering.medewerkerId);
            return View(reservering);
        }

        // GET: reserveringen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservering = await _context.reservering.FindAsync(id);
            if (reservering == null)
            {
                return NotFound();
            }
            ViewData["medewerkerId"] = new SelectList(_context.Users, "Id", "Id", reservering.medewerkerId);
            return View(reservering);
        }

        // POST: reserveringen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,voornaam,achternaam,aantal,email,telefoon,datum,begintijd,eindtijd,aangemaakt,opmerking,medewerkerId")] reservering reservering)
        {
            if (id != reservering.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservering);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!reserveringExists(reservering.Id))
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
            ViewData["medewerkerId"] = new SelectList(_context.Users, "Id", "Id", reservering.medewerkerId);
            return View(reservering);
        }

        // GET: reserveringen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservering = await _context.reservering
                .Include(r => r.medewerker)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservering == null)
            {
                return NotFound();
            }

            return View(reservering);
        }

        // POST: reserveringen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservering = await _context.reservering.FindAsync(id);
            _context.reservering.Remove(reservering);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool reserveringExists(int id)
        {
            return _context.reservering.Any(e => e.Id == id);
        }
    }
}
