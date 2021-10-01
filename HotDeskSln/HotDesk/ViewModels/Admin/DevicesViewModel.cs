using HotDesk.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotDesk.ViewModels
{
    public class DevicesViewModel
    {
        public IEnumerable<Device> Devices { get; set; }

        [Required(ErrorMessage = "Device name cannot be null")]
        [Remote(action: "CheckDeviceName", controller: "Admin", ErrorMessage = "This device already exists.")]
        public string DeviceName { get; set; }
    }
}
