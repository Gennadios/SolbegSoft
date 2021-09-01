using Microsoft.AspNetCore.Mvc;
using MvcCalculator.Models;

namespace MvcCalculator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new Calculator());
        }

        [HttpPost]
        public IActionResult Index(Calculator calculator, string operation)
        {
            calculator.Solve(operation);

            return View(calculator);
        }
    }
}