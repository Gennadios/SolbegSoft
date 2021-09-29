using System;
using HotDesk.Models;
using HotDesk.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HotDesk.Controllers
{
    [Authorize(Roles = "employee")]
    public class HomeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public HomeController(IEmployeeService employeeService) => _employeeService = employeeService;

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(DateTime preferredDate)
        {
            TempData["date"] = preferredDate;
            var model = _employeeService.GetAvailableWorkplaces(preferredDate);

            return View(model);
        }

        [HttpPost]
        public IActionResult MakeReservation(int workplaceId)
        {
            TempData["workplaceId"] = workplaceId;
            var model = _employeeService.GetAllDevices();

            return View(model);
        }

        [HttpPost]
        public IActionResult ReservationConfirmation(params int[] deviceIds)
        {
            var newReservation = new Reservation()
            {
                Date = (DateTime)TempData["date"],
                WorkplaceId = (int)TempData["workplaceId"],
                UserId = _employeeService.GetMyId(User.Identity.Name),
                Devices = _employeeService.BookDevices(deviceIds)
            };

            _employeeService.MakeReservation(newReservation);
            return View(newReservation);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
