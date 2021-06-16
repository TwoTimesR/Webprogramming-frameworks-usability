using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Studenten.Data;
using Studenten.Models;

namespace Studenten.Controllers
{
    public class LikeInfo
    {
        public int Aantal { get; set; }
    }

    public class ViewModel
    {
        public List<Student> studenten { get; set; } = new List<Student>();

        public Student student { get; set; }
    }

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewModel viewModel = new ViewModel();
            viewModel.studenten = await _context.Studenten.ToListAsync();

            return View(viewModel);
        }

        [HttpGet]
        public JsonResult Like()
        {
            return Json(new LikeInfo { Aantal = 12 });
        }

        [HttpGet]
        public async Task<JsonResult> GetStudentList()
        {
            return Json(await _context.Studenten.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStudent([Bind("StudentId,Naam,Leeftijd")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Studenten.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
