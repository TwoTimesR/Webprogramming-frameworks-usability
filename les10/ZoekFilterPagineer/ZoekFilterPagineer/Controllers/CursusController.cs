using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZoekFilterPagineer.Data;
using ZoekFilterPagineer.Models;

namespace ZoekFilterPagineer.Controllers
{
    public class CursusController : Controller
    {
        private readonly DataContext _context;

        public CursusController(DataContext context)
        {
            _context = context;
        }

        // GET: Cursus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cursussen.ToListAsync());
        }

        // GET: Cursus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursus = await _context.Cursussen
                .FirstOrDefaultAsync(m => m.CursusId == id);
            if (cursus == null)
            {
                return NotFound();
            }

            return View(cursus);
        }

        // GET: Cursus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cursus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CursusId,CursusNaam")] Cursus cursus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cursus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cursus);
        }

        // GET: Cursus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursus = await _context.Cursussen.FindAsync(id);
            if (cursus == null)
            {
                return NotFound();
            }
            return View(cursus);
        }

        // POST: Cursus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CursusId,CursusNaam")] Cursus cursus)
        {
            if (id != cursus.CursusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cursus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursusExists(cursus.CursusId))
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
            return View(cursus);
        }

        // GET: Cursus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursus = await _context.Cursussen
                .FirstOrDefaultAsync(m => m.CursusId == id);
            if (cursus == null)
            {
                return NotFound();
            }

            return View(cursus);
        }

        // POST: Cursus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cursus = await _context.Cursussen.FindAsync(id);
            _context.Cursussen.Remove(cursus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursusExists(int id)
        {
            return _context.Cursussen.Any(e => e.CursusId == id);
        }
    }
}
