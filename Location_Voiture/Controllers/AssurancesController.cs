using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Location_Voiture.Models;

namespace Location_Voiture.Controllers
{
    public class AssurancesController : Controller
    {
        private readonly MyContext _context;

        public AssurancesController(MyContext context)
        {
            _context = context;
        }

        // GET: Assurances
        public async Task<IActionResult> Index()
        {
              return View(await _context.Assurances.ToListAsync());
        }

        // GET: Assurances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Assurances == null)
            {
                return NotFound();
            }

            var assurance = await _context.Assurances
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assurance == null)
            {
                return NotFound();
            }

            return View(assurance);
        }

        // GET: Assurances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Assurances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Agence,DateDebut,DateFin,Prix")] Assurance assurance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assurance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assurance);
        }

        // GET: Assurances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Assurances == null)
            {
                return NotFound();
            }

            var assurance = await _context.Assurances.FindAsync(id);
            if (assurance == null)
            {
                return NotFound();
            }
            return View(assurance);
        }

        // POST: Assurances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Agence,DateDebut,DateFin,Prix")] Assurance assurance)
        {
            if (id != assurance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assurance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssuranceExists(assurance.Id))
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
            return View(assurance);
        }

        // GET: Assurances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Assurances == null)
            {
                return NotFound();
            }

            var assurance = await _context.Assurances
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assurance == null)
            {
                return NotFound();
            }

            return View(assurance);
        }

        // POST: Assurances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Assurances == null)
            {
                return Problem("Entity set 'MyContext.Assurances'  is null.");
            }
            var assurance = await _context.Assurances.FindAsync(id);
            if (assurance != null)
            {
                _context.Assurances.Remove(assurance);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssuranceExists(int id)
        {
          return _context.Assurances.Any(e => e.Id == id);
        }
    }
}
