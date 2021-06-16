using AuthenticationAuthorisation.Areas.Identity.Data;
using AuthenticationAuthorisation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationAuthorisation.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<SchoolUser> _userManager;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, UserManager<SchoolUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
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

        public async void ChangeUserRole()
        {
            var foundUser = await _userManager.GetUserAsync(User);
            var RolesOfFoundser = await _userManager.GetRolesAsync(foundUser);
            if (RolesOfFoundser.Contains("Student") || RolesOfFoundser.Count == 0)
            {
                await _userManager.RemoveFromRoleAsync(foundUser, "Student");
                await _userManager.AddToRoleAsync(foundUser, "Docent");
            }
            else if (RolesOfFoundser.Contains("Docent"))
            {
                await _userManager.RemoveFromRoleAsync(foundUser, "Docent");
                await _userManager.AddToRoleAsync(foundUser, "Student");
            }
        }

        public IActionResult SwitchUsers() {
            this.ChangeUserRole();
            return View("Index");
        }
    }
}
