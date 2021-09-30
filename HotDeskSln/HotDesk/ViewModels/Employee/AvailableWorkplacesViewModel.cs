using HotDesk.Models;
using System.Collections.Generic;

namespace HotDesk.ViewModels
{
    public class AvailableWorkplacesViewModel
    {
        public string DateString { get; set; }
        public IEnumerable<Workplace> Workplaces { get; set; }
    }
}
