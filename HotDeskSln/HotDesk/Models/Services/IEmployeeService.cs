using System;
using System.Collections.Generic;

namespace HotDesk.Models.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Workplace> GetAvailableWorkplaces(DateTime preferredDate);
        IEnumerable<Device> GetAllDevices();
        IEnumerable<Device> BookDevices(int[] deviceIds);
        IEnumerable<Reservation> GetCurrentUserReservations(string userLogin);
        void MakeReservation(Reservation reservation);
        int GetCurrentUserId(string userLogin);
    }
}
