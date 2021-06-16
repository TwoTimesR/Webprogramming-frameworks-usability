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
    public class ToetsResultaatController : Controller
    {
        private readonly DataContext _context;

        public ToetsResultaatController(DataContext context)
        {
            _context = context;
        }

        // GET: ToetsResultaat
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.ToetsResultaten.Include(t => t.Docent).Include(t => t.Student);
            return View(await dataContext.ToListAsync());
        }

        // GET: ToetsResultaat/Details/5
        public async Task<IActionResult> Details(int? StudentId, DateTime? Datum)
        {
            if (StudentId == null || Datum == null)
            {
                return NotFound();
            }

            var toetsResultaat = await _context.ToetsResultaten
                .Include(t => t.Docent)
                .Include(t => t.Student)
                .FirstOrDefaultAsync(m => m.StudentId == StudentId);
            if (toetsResultaat == null)
            {
                return NotFound();
            }

            return View(toetsResultaat);
        }

        // GET: ToetsResultaat/Create
        public IActionResult Create()
        {
            ViewData["DocentId"] = new SelectList(_context.Docenten, "DocentId", "DocentNaam");
            ViewData["StudentId"] = new SelectList(_context.Studenten, "StudentId", "StudentNaam");
            return View();
        }

        // POST: ToetsResultaat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,Datum,Cijfer,DocentId")] ToetsResultaat toetsResultaat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toetsResultaat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DocentId"] = new SelectList(_context.Docenten, "DocentId", "DocentNaam", toetsResultaat.DocentId);
            ViewData["StudentId"] = new SelectList(_context.Studenten, "StudentId", "StudentNaam", toetsResultaat.StudentId);
            return View(toetsResultaat);
        }

        // GET: ToetsResultaat/Edit/5
        public async Task<IActionResult> Edit(int? StudentId, DateTime? Datum)
        {
            if (StudentId == null || Datum == null)
            {
                return NotFound();
            }

            var toetsResultaat = await _context.ToetsResultaten.FindAsync(StudentId, Datum);
            if (toetsResultaat == null)
            {
                return NotFound();
            }
            ViewData["DocentId"] = new SelectList(_context.Docenten, "DocentId", "DocentNaam", toetsResultaat.DocentId);
            ViewData["StudentId"] = new SelectList(_context.Studenten, "StudentId", "StudentNaam", toetsResultaat.StudentId);
            return View(toetsResultaat);
        }

        // POST: ToetsResultaat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int StudentId, DateTime Datum, [Bind("StudentId,Datum,Cijfer,DocentId")] ToetsResultaat toetsResultaat)
        {
            if (StudentId != toetsResultaat.StudentId || Datum != toetsResultaat.Datum)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toetsResultaat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToetsResultaatExists(toetsResultaat.StudentId))
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
            ViewData["DocentId"] = new SelectList(_context.Docenten, "DocentId", "DocentNaam", toetsResultaat.DocentId);
            ViewData["StudentId"] = new SelectList(_context.Studenten, "StudentId", "StudentNaam", toetsResultaat.StudentId);
            return View(toetsResultaat);
        }

        // GET: ToetsResultaat/Delete/5
        public async Task<IActionResult> Delete(int? StudentId, DateTime? Datum)
        {
            if (StudentId == null || Datum == null)
            {
                return NotFound();
            }

            var toetsResultaat = await _context.ToetsResultaten
                .Include(t => t.Docent)
                .Include(t => t.Student)
                .FirstOrDefaultAsync(m => m.StudentId == StudentId);
            if (toetsResultaat == null)
            {
                return NotFound();
            }

            return View(toetsResultaat);
        }

        // POST: ToetsResultaat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int StudentId, DateTime Datum)
        {
            var toetsResultaat = await _context.ToetsResultaten.FindAsync(StudentId, Datum);
            _context.ToetsResultaten.Remove(toetsResultaat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToetsResultaatExists(int id)
        {
            return _context.ToetsResultaten.Any(e => e.StudentId == id);
        }
    }
}
