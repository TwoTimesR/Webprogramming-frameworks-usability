using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Studentenlijst.Models;

namespace Studentenlijst.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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

        private Student GetStudent(int studentId) {
            Student result = null;
            foreach (Student student in LijstMetStudenten.GetInstance().lijst) {
                if (student.Id == studentId) {
                    result = student;
                }
            }
            return result;
        }

        public IActionResult studentDetails(int studentId) {
            Console.WriteLine(studentId);
            Student student = GetStudent(studentId);
            return View(student);
        }
    } 
}
