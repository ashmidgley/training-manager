using LiftManager.Models;
using System.Collections.Generic;

namespace LiftManager.ViewModels
{
    public class WorkoutsViewModel
    {
        public IEnumerable<Workout> WorkoutsToDisplay { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
    }
}
