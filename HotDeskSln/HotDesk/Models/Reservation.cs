using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotDesk.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int WorkplaceId { get; set; }
        public virtual Workplace Workplace { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual IEnumerable<Device> Devices { get; set; }
    }
}
