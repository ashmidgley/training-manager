using TrainingManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace TrainingManager.ViewModels
{
    public class PlansViewModel
    {
        public IEnumerable<Plan> PlansToDisplay { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
        public ILookup<int, Favourite> Favourites { get; set; }
        public ILookup<int, Rating> Ratings { get; set; }
        public string SearchTerm { get; set; }
        public string UserId { get; set; }
    }
}
