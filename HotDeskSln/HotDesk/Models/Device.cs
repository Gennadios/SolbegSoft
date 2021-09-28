using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotDesk.Models
{
    public class Device
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<Reservation> Reservations { get; set; }
    }
}
