using TrainingManager.Models;
using System.Collections.Generic;

namespace TrainingManager.ViewModels
{
    public class RatingsViewModel
    {
        public IEnumerable<Rating> RatingsToDisplay { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
        public string UserId { get; set; }
    }
}
