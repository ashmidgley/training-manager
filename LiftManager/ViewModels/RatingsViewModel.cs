using LiftManager.Models;
using System.Collections.Generic;

namespace LiftManager.ViewModels
{
    public class RatingsViewModel
    {
        public IEnumerable<Rating> RatingsToDisplay { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
    }
}
