using System.Collections.Generic;

namespace HotDesk.Models.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Workplace> GetAvailableWorkplaces();
        void MakeReservation(Reservation reservation);
    }
}
