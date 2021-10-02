using System;
using HotDesk.Models.Repositories;
using System.Collections.Generic;

namespace HotDesk.Models.Services
{
    public class AdminService : IAdminService
    {
        private readonly IRepository _repository;

        public AdminService(IRepository repository) => _repository = repository;

        public T Get<T>(Func<T, bool> predicate) where T : class
        {
            return _repository.Get(predicate);
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            return _repository.GetAll<T>();
        }

        public void Add<T>(T item) where T : class
        {
            _repository.Add(item);
            _repository.SaveChanges();
        }

        public void Remove<T>(T item) where T : class
        {
            if (item is Role && CantRemoveRole(item as Role))
                return;

            _repository.Remove(item);
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
            foreach (var reservation in allReservations)
            {
                if (reservation.StatusId == 1 && DateTime.Now.Day > reservation.Date.Day)
                    reservation.StatusId = 3;
            }
        }

        // to avoid deleting admin or employee
        private bool CantRemoveRole(Role role)
        {
            return role.Id == 1 || role.Id == 2;
        }

        // couldn't update Devices navigation property, had to recreate reservation with new devices
        // TODO: optimize Devices update
        public void UpdateDevices(int reservationId, int[] deviceIds)
        {
            var newDevices = new List<Device>();
            foreach (var id in deviceIds)
            {
                newDevices.Add(_repository.Get<Device>(d => d.Id == id));
            }

            var reservationToUpdate = _repository.Get<Reservation>(r => r.Id == reservationId);
            var newReservation = new Reservation
            {
                Date = reservationToUpdate.Date,
                UserId = reservationToUpdate.UserId,
                WorkplaceId = reservationToUpdate.WorkplaceId,
                Devices = newDevices,
                StatusId = reservationToUpdate.StatusId
            };

            _repository.Remove(reservationToUpdate);
            _repository.Add(newReservation);
            
            _repository.SaveChanges();
        }
    }
}
