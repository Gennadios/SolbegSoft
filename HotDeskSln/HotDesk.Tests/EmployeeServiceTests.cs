using Xunit;
using Moq;
using System.Linq;
using HotDesk.Models.Repositories;
using HotDesk.Models.Services;
using HotDesk.Models;
using System;

namespace HotDesk.Tests
{
    public class EmployeeServiceTests
    {
        private readonly EmployeeService _systemUnderTest;
        private readonly Mock<IRepository> _repository = new Mock<IRepository>();

        public EmployeeServiceTests() => _systemUnderTest = new EmployeeService(_repository.Object);

        [Fact]
        public void Can_Get_Workplaces_That_Are_Not_Reserved()
        {
            // Arrange
            DateTime preferredDate = new DateTime(2021, 10, 10);

            _repository.Setup(x => x.GetAll<Workplace>()).Returns(new Workplace[]
            {
                new Workplace { Id = 1 },
                new Workplace { Id = 2 },
                new Workplace { Id = 3 }
            }.AsQueryable());

            _repository.Setup(x => x.GetAll<Reservation>()).Returns(new Reservation[]
            {
                new Reservation { Id = 1, StatusId = 1, Date = preferredDate, WorkplaceId = 1 },
                new Reservation { Id = 2, StatusId = 1, Date = new DateTime(2021, 10, 20), WorkplaceId = 2 },
                new Reservation { Id = 3, StatusId = 2, Date = new DateTime(2021, 10, 1), WorkplaceId = 2 },
                new Reservation { Id = 4, StatusId = 1, Date = preferredDate, WorkplaceId = 3 },
                new Reservation { Id = 5, StatusId = 3, Date = new DateTime(2021, 10, 12), WorkplaceId = 3 }
            }.AsQueryable());

            // Act
            var actualCount = _systemUnderTest.GetAvailableWorkplaces(preferredDate).Count();

            // Assert
            Assert.Equal(2, actualCount);
        }

        [Fact]
        public void Can_Get_All_Devices()
        {
            // Arrange
            _repository.Setup(x => x.GetAll<Device>()).Returns(new Device[]
            {
                new Device { Id = 1},
                new Device { Id = 2},
                new Device { Id = 3}
            }.AsQueryable());

            // Act
            var actualCount = _systemUnderTest.GetAllDevices().Count();

            // Assert
            Assert.Equal(3, actualCount);
        }

        [Fact]
        public void Can_Book_Devices_By_Ids()
        {
            // Arrange
            int[] deviceIds = new int[] { 1, 3, 5 };
            _repository.Setup(x => x.GetAll<Device>()).Returns(new Device[]
            {
                new Device { Id = 1},
                new Device { Id = 2},
                new Device { Id = 3},
                new Device { Id = 4},
                new Device { Id = 5}
            }.AsQueryable());

            // Act
            var actualCount = _systemUnderTest.BookDevices(deviceIds).Count();

            // Assert
            Assert.Equal(3, actualCount);
        }

        [Fact]
        public void Can_Get_Current_User_Id()
        {
            // Arrange
            var expectedUser = new User
            {
                Id = 4,
                Login = "user4"
            };

            _repository.Setup(x => x.GetAll<User>()).Returns(new User[]
            {
                new User { Id = 1, Login = "user1" },
                new User { Id = 2, Login = "user2" },
                new User { Id = 3, Login = "user3" },
                expectedUser,
                new User { Id = 5, Login = "user5" }
            }.AsQueryable());

            // Act
            var actualUser = _systemUnderTest.GetCurrentUserId("user4");

            // Assert
            Assert.Equal(expectedUser.Id, actualUser);
        }

        [Fact]
        public void Can_Get_Current_User_Reservations()
        {
            // Arrange
            var currentUser = new User { Login = "user1" };

            _repository.Setup(x => x.GetAll<Reservation>()).Returns(new Reservation[]
            {
                new Reservation { Id = 1, User = currentUser },
                new Reservation { Id = 2, User = currentUser },
                new Reservation { Id = 3 },
                new Reservation { Id = 4, User = currentUser },
                new Reservation { Id = 5 },
            }.AsQueryable());

            // Act
            var actualCount = _systemUnderTest.GetCurrentUserReservations(currentUser.Login).Count();

            // Assert
            Assert.Equal(3, actualCount);
        }
    }
}
