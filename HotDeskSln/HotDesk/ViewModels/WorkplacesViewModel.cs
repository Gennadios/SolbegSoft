using HotDesk.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotDesk.ViewModels
{
    public class WorkplacesViewModel
    {
        public IEnumerable<Workplace> Workplaces { get; set; }

        [Required(ErrorMessage = "Description cannot be null")]
        public string Description { get; set; }
        public bool? HasDesktop { get; set; }
    }
}
