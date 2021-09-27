using System.ComponentModel.DataAnnotations;

namespace HotDesk.Models
{
    public class Device
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
