using System;
using HotDesk.Models;
using HotDesk.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using HotDesk.ViewModels;

namespace HotDesk.Controllers
{
    [Authorize(Roles = "employee")]
    public class HomeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private string CurrentUserLogin { get => User.Identity.Name; }

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

            var viewModel = new AvailableWorkplacesViewModel
            {
                DateString = preferredDate.ToString("yyyy-MM-dd"),
                Workplaces = _employeeService.GetAvailableWorkplaces(preferredDate)
            };

            _employeeService.UpdateReservationStatuses();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult MakeReservation(int workplaceId)
        {
            TempData["workplaceId"] = workplaceId;
            TempData.Keep();

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
                UserId = _employeeService.GetCurrentUserId(CurrentUserLogin),
                Devices = _employeeService.BookDevices(deviceIds),
                StatusId = 1
            };

            _employeeService.MakeReservation(newReservation);
            TempData.Clear();

            return View(newReservation);
        }

        [HttpGet]
        public IActionResult UserReservations()
        {
            var model = _employeeService.GetCurrentUserReservations(CurrentUserLogin);
            _employeeService.UpdateReservationStatuses();

            return View(model);
        }

        [HttpPost]
        public IActionResult UserReservations(int reservationId)
        {
            if (reservationId != 0)
                _employeeService.CancelReservation(reservationId);

            var model = _employeeService.GetCurrentUserReservations(CurrentUserLogin);
            _employeeService.UpdateReservationStatuses();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
