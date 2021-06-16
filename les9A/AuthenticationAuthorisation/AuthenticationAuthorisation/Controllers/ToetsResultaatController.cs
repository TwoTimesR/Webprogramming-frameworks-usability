using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AuthenticationAuthorisation.Models;
using AuthenticationAuthorisation.Data;
using Microsoft.AspNetCore.Authorization;
using AuthenticationAuthorisation.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;

namespace AuthenticationAuthorisation.Controllers
{
    [Authorize(Roles = "Docent")]
    public class ToetsResultaatController : Controller
    {
        private readonly UserContext _context;
        private readonly UserManager<SchoolUser> _userManager;

        public ToetsResultaatController(UserContext context, UserManager<SchoolUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = "Docent, Student")]
        public ViewResult Zoek(string naam, int? cijfer)
        {
            if (naam == null && cijfer == null)
            {
                return View("ZoekForm");
            }
            else
            {
                //var resultEx = _context.ToetsResultaat.Where(p => p.StudentNaam == naam || p.Cijfer == cijfer).ToList();

                List<ToetsResultaat> resultEx = new List<ToetsResultaat>();
                string query = $"SELECT * FROM ToetsResultaat WHERE StudentNaam LIKE '{naam}' OR Cijfer = {cijfer}";
                resultEx = _context.ToetsResultaat.FromSqlRaw(query).ToList();

                return View(resultEx);
            }
        }

        [AllowAnonymous]
        // GET: ToetsResultaat
        public async Task<IActionResult> Index()
        {
            var foundUser = await _userManager.GetUserAsync(User);
            var RolesOfFoundser = await _userManager.GetRolesAsync(foundUser);
            return View(await _context.ToetsResultaat.ToListAsync());
        }

        [AllowAnonymous]
        // GET: ToetsResultaat/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toetsResultaat = await _context.ToetsResultaat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toetsResultaat == null)
            {
                return NotFound();
            }

            return View(toetsResultaat);
        }

        // GET: ToetsResultaat/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToetsResultaat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentNaam,Cijfer")] ToetsResultaat toetsResultaat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toetsResultaat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(toetsResultaat);
        }

        // GET: ToetsResultaat/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toetsResultaat = await _context.ToetsResultaat.FindAsync(id);
            if (toetsResultaat == null)
            {
                return NotFound();
            }
            return View(toetsResultaat);
        }

        // POST: ToetsResultaat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentNaam,Cijfer")] ToetsResultaat toetsResultaat)
        {
            if (id != toetsResultaat.Id)
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
                    if (!ToetsResultaatExists(toetsResultaat.Id))
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
            return View(toetsResultaat);
        }

        // GET: ToetsResultaat/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toetsResultaat = await _context.ToetsResultaat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toetsResultaat == null)
            {
                return NotFound();
            }

            return View(toetsResultaat);
        }

        // POST: ToetsResultaat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toetsResultaat = await _context.ToetsResultaat.FindAsync(id);
            _context.ToetsResultaat.Remove(toetsResultaat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToetsResultaatExists(int id)
        {
            return _context.ToetsResultaat.Any(e => e.Id == id);
        }
    }
}
