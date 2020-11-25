using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dinda.Models;

namespace Dinda.Migrations
{
    public class MadrinhasController : Controller
    {
        private readonly Context _context;

        public MadrinhasController(Context context)
        {
            _context = context;
        }

        // GET: Madrinhas
        public async Task<IActionResult> Index()
        {
            var context = _context.Madrinhas.Include(m => m.Conhecimentos);
            return View(await context.ToListAsync());
        }

        // GET: Madrinhas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var madrinhas = await _context.Madrinhas
                .Include(m => m.Conhecimentos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (madrinhas == null)
            {
                return NotFound();
            }

            return View(madrinhas);
        }

        // GET: Madrinhas/Create
        public IActionResult Create()
        {
            ViewData["ConhecimentosId"] = new SelectList(_context.Conhecimentos, "Id", "Id");
            return View();
        }

        // POST: Madrinhas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ConhecimentosId")] Madrinhas madrinhas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(madrinhas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConhecimentosId"] = new SelectList(_context.Conhecimentos, "Id", "Id", madrinhas.ConhecimentosId);
            return View(madrinhas);
        }

        // GET: Madrinhas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var madrinhas = await _context.Madrinhas.FindAsync(id);
            if (madrinhas == null)
            {
                return NotFound();
            }
            ViewData["ConhecimentosId"] = new SelectList(_context.Conhecimentos, "Id", "Id", madrinhas.ConhecimentosId);
            return View(madrinhas);
        }

        // POST: Madrinhas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ConhecimentosId")] Madrinhas madrinhas)
        {
            if (id != madrinhas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(madrinhas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MadrinhasExists(madrinhas.Id))
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
            ViewData["ConhecimentosId"] = new SelectList(_context.Conhecimentos, "Id", "Id", madrinhas.ConhecimentosId);
            return View(madrinhas);
        }

        // GET: Madrinhas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var madrinhas = await _context.Madrinhas
                .Include(m => m.Conhecimentos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (madrinhas == null)
            {
                return NotFound();
            }

            return View(madrinhas);
        }

        // POST: Madrinhas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var madrinhas = await _context.Madrinhas.FindAsync(id);
            _context.Madrinhas.Remove(madrinhas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MadrinhasExists(int id)
        {
            return _context.Madrinhas.Any(e => e.Id == id);
        }
    }
}
