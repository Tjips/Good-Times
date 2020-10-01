using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoodTimes.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoodTimes.Controllers
{
    public class bonnetjesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public bonnetjesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.bestelling = await _context.bestelling.ToListAsync();

            var applicationDbContext = _context.bon.Include(p => p.Tafel);
            return View(await applicationDbContext.ToListAsync());
        }
    }
}
