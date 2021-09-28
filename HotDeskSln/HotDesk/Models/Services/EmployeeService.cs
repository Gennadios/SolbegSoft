using HotDesk.Models.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace HotDesk.Models.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository _repository;

        public EmployeeService(IRepository repository) => _repository = repository;

        public IEnumerable<Workplace> GetAvailableWorkplaces()
        {
            // TODO: optimize
            var allWorkplaces = _repository.GetAll<Workplace>().ToArray();
            var reservedWorkplaces = _repository.GetAll<Reservation>().ToArray().Where(r => r.IsActive).Select(x => x.Workplace);

            return allWorkplaces.Except(reservedWorkplaces);
        }

        public void MakeReservation(Reservation reservation)
        {
            _repository.Add(reservation);
        }
    }
}
