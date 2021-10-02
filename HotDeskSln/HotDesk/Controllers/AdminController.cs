using System.Linq;
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
                Roles = _adminService.GetAll<Role>(),
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
            viewModel.Roles = _adminService.GetAll<Role>();

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
            _adminService.UpdateReservationStatuses();
            var model = _adminService.GetAll<Reservation>();
            return View(model);
        }

        [HttpPost]
        public IActionResult Reservations(int reservationToCancelId, int reservationToEditId, params int[] deviceIds)
        {
            if (reservationToCancelId != 0)
                _adminService.CancelReservation(reservationToCancelId);

            if (reservationToEditId != 0)
                _adminService.UpdateDevices(reservationToEditId, deviceIds);

            _adminService.UpdateReservationStatuses();
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

        #region Validation Actions
        [AcceptVerbs("GET", "POST")]
        public IActionResult CheckRoleName([Bind(Prefix = "RoleName")] string roleName)
        {
            bool roleExists = _adminService.GetAll<Role>().Any(r => r?.Name.ToUpper() == roleName?.ToUpper());

            if (roleExists)
                return Json(false);
            return Json(true);
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult CheckDeviceName([Bind(Prefix = "DeviceName")] string deviceName)
        {
            bool deviceExists = _adminService.GetAll<Device>().Any(d => d?.Name.ToUpper() == deviceName?.ToUpper());

            if (deviceExists)
                return Json(false);

            return Json(true);
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult CheckUserLogin([Bind(Prefix = "Login")] string userLogin)
        {
            bool loginExists = _adminService.GetAll<User>().Any(u => u?.Login.ToUpper() == userLogin?.ToUpper());

            if (loginExists)
                return Json(false);

            return Json(true);
        }
    } 
    #endregion
}
