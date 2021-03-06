using HotDesk.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotDesk.Models.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository _repository;

        public EmployeeService(IRepository repository) => _repository = repository;

        public IEnumerable<Workplace> GetAvailableWorkplaces(DateTime preferredDate)
        {
            // TODO: optimize
            var allWorkplaces = _repository.GetAll<Workplace>().ToList();
            var reservedWorkplaces = _repository.GetAll<Reservation>()
                .Where(r => r.StatusId == 1 && r.Date == preferredDate)
                .Select(x => x.Workplace)
                .ToList();
            
            return allWorkplaces.Except(reservedWorkplaces);
        }

        public IEnumerable<Device> GetAllDevices()
        {
            return _repository.GetAll<Device>();
        }

        public IEnumerable<Device> BookDevices(int[] deviceIds)
        {
            var output = new List<Device>();

            foreach(var id in deviceIds)
            {
                output.Add(_repository.Get<Device>(d => d.Id == id));
            }

            return output;
        }

        public void MakeReservation(Reservation reservation)
        {
            _repository.Add(reservation);
            _repository.SaveChanges();
        }

        public void CancelReservation(int reservationId)
        {
            var reservationToModify = _repository.Get<Reservation>(r => r.Id == reservationId);
            reservationToModify.StatusId = 3;
            _repository.SaveChanges();
        }

        public void UpdateReservationStatuses()
        {
            var allReservations = _repository.GetAll<Reservation>();

            // set reservation status to complete if it wasn't cancelled and the date is expired
            foreach(var reservation in allReservations)
            {
                if (reservation.StatusId == 1 && DateTime.Now.Day > reservation.Date.Day)
                    reservation.StatusId = 2;
            }

            _repository.SaveChanges();
        }

        public int GetCurrentUserId(string userLogin)
        {
            return _repository.Get<User>(u => u.Login == userLogin).Id;
        }

        public IEnumerable<Reservation> GetCurrentUserReservations(string userLogin)
        {
            return _repository.GetAll<Reservation>().Where(r => r.User.Login == userLogin);
        }
    }
}
