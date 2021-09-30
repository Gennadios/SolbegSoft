using HotDesk.Models;
using HotDesk.Models.Services;
using HotDesk.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace HotDesk.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService) => _adminService = adminService;

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        #region Role Actions
        [HttpGet]
        public IActionResult Roles()
        {
            var model = new RolesViewModel()
            {
                Roles = _adminService.GetAll<Role>()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Roles(RolesViewModel viewModel, int roleId)
        {
            if (ModelState.IsValid)
                _adminService.Add(new Role { Name = viewModel.RoleName });

            if (roleId != 0)
            {
                var roleToRemove = _adminService.Get<Role>(role => role.Id == roleId);
                _adminService.Remove(roleToRemove);
            }

            viewModel.Roles = _adminService.GetAll<Role>();
            return View(viewModel);
        }
        #endregion

        #region User Actions
        [HttpGet]
        public IActionResult Users()
        {
            var model = new UsersViewModel()
            {
                Users = _adminService.GetAll<User>()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Users(UsersViewModel viewModel, int userId)
        {
            if (ModelState.IsValid)
            {
                User newUser = new User
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Login = viewModel.Login,
                    Password = viewModel.Password,
                    RoleId = viewModel.RoleId
                };

                _adminService.Add(newUser);
            }

            if (userId != 0)
            {
                var userToRemove = _adminService.Get<User>(user => user.Id == userId);
                _adminService.Remove(userToRemove);
            }

            viewModel.Users = _adminService.GetAll<User>();
            return View(viewModel);
        }
        #endregion

        #region Workplace Actions
        [HttpGet]
        public IActionResult Workplaces()
        {
            var model = new WorkplacesViewModel()
            {
                Workplaces = _adminService.GetAll<Workplace>()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Workplaces(WorkplacesViewModel viewModel, int workplaceId)
        {
            if (ModelState.IsValid)
            {
                var newWorkplace = new Workplace
                {
                    Description = viewModel.Description,
                    HasDesktop = viewModel.HasDesktop
                };
                _adminService.Add(newWorkplace);
            }

            if (workplaceId != 0)
            {
                var workplaceToRemove = _adminService.Get<Workplace>(w => w.Id == workplaceId);
                _adminService.Remove(workplaceToRemove);
            }

            viewModel.Workplaces = _adminService.GetAll<Workplace>();
            return View(viewModel);
        }
        #endregion

        #region Device Actions
        [HttpGet]
        public IActionResult Devices()
        {
            var model = new DevicesViewModel()
            {
                Devices = _adminService.GetAll<Device>()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Devices(DevicesViewModel viewModel, int deviceId)
        {
            if (ModelState.IsValid)
            {
                var newDevice = new Device
                {
                    Name = viewModel.DeviceName
                };

                _adminService.Add(newDevice);
            }

            if (deviceId != 0)
            {
                var deviceToRemove = _adminService.Get<Device>(d => d.Id == deviceId);
                _adminService.Remove(deviceToRemove);
            }   

            viewModel.Devices = _adminService.GetAll<Device>();
            return View(viewModel);
        }
        #endregion

        #region Reservation Actions
        [HttpGet]
        public IActionResult Reservations()
        {
            var model = _adminService.GetAll<Reservation>();
            return View(model);
        }

        [HttpPost]
        public IActionResult Reservations(int reservationId, params int[] deviceIds)
        {
            if (reservationId != 0)
            {
                var reservationToModify = _adminService.Get<Reservation>(r => r.Id == reservationId);
                reservationToModify.Devices = _adminService.UpdateDevices(deviceIds);
            }

            var model = _adminService.GetAll<Reservation>();
            return View(model);
        }

        [HttpPost]
        public IActionResult EditReservation(int reservationId)
        {
            var viewModel = new ReservationViewModel
            {
                Reservation = _adminService.Get<Reservation>(r => r.Id == reservationId),
                AllDevices = _adminService.GetAll<Device>()
            };  

            return View(viewModel);
        }
        #endregion
    }
}
