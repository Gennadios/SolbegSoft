using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotDesk.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        public string StatusName { get; set; }

        public virtual IEnumerable<Reservation> Reservations { get; set; }
    }
}
