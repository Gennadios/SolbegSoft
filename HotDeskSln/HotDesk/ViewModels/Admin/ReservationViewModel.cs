using HotDesk.Models;
using System.Collections.Generic;

namespace HotDesk.ViewModels
{
    public class ReservationViewModel
    {
        public Reservation Reservation {get; set;}
        public IEnumerable<Device> AllDevices { get; set; }
    }
}
