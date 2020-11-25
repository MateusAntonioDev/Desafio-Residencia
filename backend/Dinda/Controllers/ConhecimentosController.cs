using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dinda.Models;

namespace Dinda.Controllers
{
    public class ConhecimentosController : Controller
    {
        private readonly Context _context;

        public ConhecimentosController(Context context)
        {
            _context = context;
        }

        // GET: Conhecimentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Conhecimentos.ToListAsync());
        }

        // GET: Conhecimentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conhecimentos = await _context.Conhecimentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conhecimentos == null)
            {
                return NotFound();
            }

            return View(conhecimentos);
        }

        // GET: Conhecimentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Conhecimentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] Conhecimentos conhecimentos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conhecimentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(conhecimentos);
        }

        // GET: Conhecimentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conhecimentos = await _context.Conhecimentos.FindAsync(id);
            if (conhecimentos == null)
            {
                return NotFound();
            }
            return View(conhecimentos);
        }

        // POST: Conhecimentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Conhecimentos conhecimentos)
        {
            if (id != conhecimentos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conhecimentos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConhecimentosExists(conhecimentos.Id))
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
            return View(conhecimentos);
        }

        // GET: Conhecimentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conhecimentos = await _context.Conhecimentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conhecimentos == null)
            {
                return NotFound();
            }

            return View(conhecimentos);
        }

        // POST: Conhecimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conhecimentos = await _context.Conhecimentos.FindAsync(id);
            _context.Conhecimentos.Remove(conhecimentos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConhecimentosExists(int id)
        {
            return _context.Conhecimentos.Any(e => e.Id == id);
        }
    }
}
