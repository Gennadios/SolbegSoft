using HotDesk.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotDesk.ViewModels
{
    public class WorkplacesViewModel
    {
        public IEnumerable<Workplace> Workplaces { get; set; }

        [Required(ErrorMessage = "Description cannot be null")]
        [RegularExpression(@"[A-Za-z0-9\s]+", ErrorMessage = "Only latin characters and numbers allowed.")]
        [StringLength(200, MinimumLength = 20, ErrorMessage = "Description should be between 20 and  200 characters long.")]
        public string Description { get; set; }
        public bool HasDesktop { get; set; }
    }
}
