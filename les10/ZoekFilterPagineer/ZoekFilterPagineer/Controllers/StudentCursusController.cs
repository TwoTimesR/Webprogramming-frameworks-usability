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
    public class StudentCursusController : Controller
    {
        private readonly DataContext _context;

        public StudentCursusController(DataContext context)
        {
            _context = context;
        }

        // GET: StudentCursus
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.StudentCursussen.Include(s => s.Cursus).Include(s => s.Student);
            return View(await dataContext.ToListAsync());
        }

        // GET: StudentCursus/Details/5
        public async Task<IActionResult> Details(int? StudentId, int? CursusId)
        {
            if (StudentId == null || CursusId == null)
            {
                return NotFound();
            }

            var studentCursus = await _context.StudentCursussen
                .Include(s => s.Cursus)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentId == StudentId && m.CursusId == CursusId);
            if (studentCursus == null)
            {
                return NotFound();
            }

            return View(studentCursus);
        }

        // GET: StudentCursus/Create
        public IActionResult Create()
        {
            ViewData["CursusId"] = new SelectList(_context.Cursussen, "CursusId", "CursusNaam");
            ViewData["StudentId"] = new SelectList(_context.Studenten, "StudentId", "StudentNaam");
            return View();
        }

        // POST: StudentCursus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,CursusId")] StudentCursus studentCursus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentCursus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursusId"] = new SelectList(_context.Cursussen, "CursusId", "CursusNaam", studentCursus.CursusId);
            ViewData["StudentId"] = new SelectList(_context.Studenten, "StudentId", "StudentNaam", studentCursus.StudentId);
            return View(studentCursus);
        }

        // GET: StudentCursus/Edit/5
        public async Task<IActionResult> Edit(int? StudentId, int? CursusId)
        {
            if (StudentId == null || CursusId == null)
            {
                return NotFound();
            }

            var studentCursus = await _context.StudentCursussen
                .Include(s => s.Cursus)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentId == StudentId && m.CursusId == CursusId);

            if (studentCursus == null)
            {
                return NotFound();
            }
            ViewData["CursusId"] = new SelectList(_context.Cursussen, "CursusId", "CursusNaam", studentCursus.CursusId);
            ViewData["StudentId"] = new SelectList(_context.Studenten, "StudentId", "StudentNaam", studentCursus.StudentId);
            return View(studentCursus);
        }

        // POST: StudentCursus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int StudentId, int CursusId, [Bind("StudentId,CursusId")] StudentCursus studentCursus)
        {
            if (StudentId != studentCursus.StudentId || CursusId != studentCursus.CursusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentCursus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentCursusExists(studentCursus.StudentId, studentCursus.CursusId))
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
            ViewData["CursusId"] = new SelectList(_context.Cursussen, "CursusId", "CursusNaam", studentCursus.CursusId);
            ViewData["StudentId"] = new SelectList(_context.Studenten, "StudentId", "StudentNaam", studentCursus.StudentId);
            return View(studentCursus);
        }

        // GET: StudentCursus/Delete/5
        public async Task<IActionResult> Delete(int? StudentId, int? CursusId)
        {
            if (StudentId == null || CursusId == null)
            {
                return NotFound();
            }

            var studentCursus = await _context.StudentCursussen
                .Include(s => s.Cursus)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentId == StudentId && m.CursusId == CursusId);
            if (studentCursus == null)
            {
                return NotFound();
            }

            return View(studentCursus);
        }

        // POST: StudentCursus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int StudentId, int CursusId)
        {
            var studentCursus = await _context.StudentCursussen.FindAsync(StudentId, CursusId);
            _context.StudentCursussen.Remove(studentCursus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentCursusExists(int StudentId, int CursusId)
        {
            return _context.StudentCursussen.Any(e => e.StudentId == StudentId && e.CursusId == CursusId);
        }
    }
}
