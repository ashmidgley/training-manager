using TrainingManager.Models;
using System.Collections.Generic;

namespace TrainingManager.ViewModels
{
    public class WorkoutsViewModel
    {
        public IEnumerable<Workout> WorkoutsToDisplay { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
    }
}
