using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Validation.Data;
using Validation.Models;

namespace Validation.Controllers
{
    public class HomeController : Controller
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            TempData["Top3"] = GetTop3Students();
        }

        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public List<Student> GetTop3Students()
        {
            var result = _context.Studenten.OrderByDescending(s => s.Studiepunten).Take(3).ToList();
            return result;
        }

        public IActionResult Index()
        {
            //TempData["Top3"] = GetTop3Students();
            var allStudents = _context.Studenten.ToList();
            return View(allStudents);
        }

        public List <Student> GetStudents() {
            using (var db = _context) {
                return db.Studenten.ToList();
            }
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
