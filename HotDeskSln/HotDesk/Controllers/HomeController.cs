using HotDesk.Data;
using HotDesk.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace HotDesk.Controllers
{
    public class HomeController : Controller
    {
        private readonly HotDeskDbContext _context;

        public HomeController(HotDeskDbContext context) => _context = context;

        [Authorize(Roles = "employee")]
        public IActionResult Index()
        {
            string role = User.FindFirst(u => u.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            return Content($"Logged in as {role}");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
