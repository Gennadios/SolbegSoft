using System.ComponentModel.DataAnnotations.Schema;

namespace HotDesk.Models
{
    public class Workplace
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool? HasDesktop { get; set; }
    }
}
