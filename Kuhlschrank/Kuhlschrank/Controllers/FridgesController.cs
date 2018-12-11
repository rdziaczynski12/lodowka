using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kuhlschrank.Models;

namespace Kuhlschrank.Controllers
{
    public class FridgesController : Controller
    {
        private readonly KuhlschrankContext _context;

        public FridgesController(KuhlschrankContext context)
        {
            _context = context;
        }

        // GET: Fridges
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fridge.ToListAsync());
        }

        // GET: Fridges/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fridge = await _context.Fridge
                .FirstOrDefaultAsync(m => m.id == id);
            if (fridge == null)
            {
                return NotFound();
            }

            return View(fridge);
        }

        // GET: Fridges/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fridges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,serialNumber,temperature,activated")] Fridge fridge)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fridge);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fridge);
        }

        // GET: Fridges/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fridge = await _context.Fridge.FindAsync(id);
            if (fridge == null)
            {
                return NotFound();
            }
            return View(fridge);
        }

        // POST: Fridges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("id,serialNumber,temperature,activated")] Fridge fridge)
        {
            if (id != fridge.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fridge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FridgeExists(fridge.id))
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
            return View(fridge);
        }

        // GET: Fridges/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fridge = await _context.Fridge
                .FirstOrDefaultAsync(m => m.id == id);
            if (fridge == null)
            {
                return NotFound();
            }

            return View(fridge);
        }

        // POST: Fridges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var fridge = await _context.Fridge.FindAsync(id);
            _context.Fridge.Remove(fridge);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FridgeExists(long id)
        {
            return _context.Fridge.Any(e => e.id == id);
        }
    }
}
