using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Security.Data;
using Security.Models;

namespace Security.Controllers
{
    public class DocentController : Controller
    {
        private readonly DataContext _context;

        public DocentController(DataContext context)
        {
            _context = context;
        }

        // GET: Docent
        public async Task<IActionResult> Index()
        {
            return View(await _context.Docenten.ToListAsync());
        }

        // GET: Docent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docent = await _context.Docenten
                .FirstOrDefaultAsync(m => m.DocentId == id);
            if (docent == null)
            {
                return NotFound();
            }

            return View(docent);
        }

        // GET: Docent/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Docent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DocentId,DocentNaam")] Docent docent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(docent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(docent);
        }

        // GET: Docent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docent = await _context.Docenten.FindAsync(id);
            if (docent == null)
            {
                return NotFound();
            }
            return View(docent);
        }

        // POST: Docent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DocentId,DocentNaam")] Docent docent)
        {
            if (id != docent.DocentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(docent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocentExists(docent.DocentId))
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
            return View(docent);
        }

        // GET: Docent/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docent = await _context.Docenten
                .FirstOrDefaultAsync(m => m.DocentId == id);
            if (docent == null)
            {
                return NotFound();
            }

            return View(docent);
        }

        // POST: Docent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var docent = await _context.Docenten.FindAsync(id);
            _context.Docenten.Remove(docent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocentExists(int id)
        {
            return _context.Docenten.Any(e => e.DocentId == id);
        }
    }
}
