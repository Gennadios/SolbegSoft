using System;
using System.Linq;
using Xunit;
using Moq;
using HotDesk.Models;
using HotDesk.Models.Repositories;
using HotDesk.Models.Services;

namespace HotDesk.Tests
{
    public class AdminServiceTests
    {
        private readonly AdminService _systemUnderTest;
        private readonly Mock<IRepository> _repository = new Mock<IRepository>();

        public AdminServiceTests() => _systemUnderTest = new AdminService(_repository.Object);

        [Fact]
        public void Can_Get_Entity_By_Predicate()
        {
            // Arrange
            int userId = 1;
            Func<User, bool> userPredicate = u => u.Id == userId;

            var expectedUser = new User
            {
                Id = userId,
                FirstName = "Bill",
                LastName = "Gates",
                Login = "windows95"
            };

            string roleName = "PowerUser";
            Func<Role, bool> rolePredicate = role => role.Name == roleName;
            var expectedRole = new Role
            {
                Id = 5,
                Name = roleName
            };

            DateTime reservationDate = new DateTime(2000, 1, 1);
            Func<Reservation, bool> reservationPredicate = r => r.Date == reservationDate;
            var expectedReservation = new Reservation
            {
                Id = 3,
                Date = reservationDate
            };

            _repository.Setup(x => x.Get(userPredicate)).Returns(expectedUser);
            _repository.Setup(x => x.Get(rolePredicate)).Returns(expectedRole);
            _repository.Setup(x => x.Get(reservationPredicate)).Returns(expectedReservation);

            // Act
            var actualUser = _systemUnderTest.Get(userPredicate);
            var actualRole = _systemUnderTest.Get(rolePredicate);
            var actualReservation = _systemUnderTest.Get(reservationPredicate);

            // Assert
            Assert.Equal(expectedUser, actualUser);
            Assert.Equal(expectedRole, actualRole);
            Assert.Equal(expectedReservation, actualReservation);
        }

        [Fact]
        public void Can_Get_All_Entities()
        {
            // Arrange
            _repository.Setup(x => x.GetAll<User>()).Returns(new User[]
            {
                new User {Id = 1},
                new User {Id = 2},
                new User {Id = 3},
                new User {Id = 4},
                new User {Id = 5},
            }.AsQueryable());

            // Act
            var actual = _systemUnderTest.GetAll<User>();

            // Assert
            Assert.Equal(5, actual.Count());
        }

        [Fact]
        public void Can_Update_Reservation_Statuses()
        {
            // Arrange
            var tomorrow = DateTime.Now.AddDays(1);
            var yesterday = DateTime.Now.AddDays(-1);
            _repository.Setup(x => x.GetAll<Reservation>()).Returns(new Reservation[]
            {
                new Reservation { Id = 1, Date = yesterday, StatusId = 1},
                new Reservation { Id = 2, Date = tomorrow, StatusId = 1},
                new Reservation { Id = 3, Date = yesterday, StatusId = 2},
                new Reservation { Id = 4, Date = tomorrow, StatusId = 3}
            }.AsQueryable());

            // Act
            _systemUnderTest.UpdateReservationStatuses();
            var expectedCount = _systemUnderTest.GetAll<Reservation>().Where(r => r.StatusId == 1).Count();

            // Assert
            Assert.Equal(1, expectedCount);
        }

        [Fact]
        public void Can_Cancel_Reservation()
        {
            // Arrange
            int reservationId = 1;
            Func<Reservation, bool> predicate = r => r.Id == reservationId;

            _repository.Setup(x => x.Get(predicate)).Returns(new Reservation
            {
                Id = reservationId,
                StatusId = 1
            });

            // Act
            _systemUnderTest.CancelReservation(reservationId);
            var expectedId = _systemUnderTest.Get(predicate).StatusId;

            // Assert
            Assert.Equal(3, expectedId);
        }
    }
}
