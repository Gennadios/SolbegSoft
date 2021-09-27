using HotDesk.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotDesk.ViewModels
{
    public class DevicesViewModel
    {
        public IEnumerable<Device> Devices { get; set; }

        [Required(ErrorMessage = "Device name cannot be null")]
        public string DeviceName { get; set; }
    }
}
