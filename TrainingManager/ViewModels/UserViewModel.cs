using TrainingManager.Models;
using System.Collections.Generic;

namespace TrainingManager.ViewModels
{
    public class UserViewModel
    {
        public string Header { get; set; }
        public ApplicationUser User { get; set; }
        public string LifterTypeFileName { get; set; }
        public IEnumerable<Plan> Plans { get; set; }
        public int PlanCount { get; set; }
        public IEnumerable<Rating> Ratings { get; set; }
        public IEnumerable<Favourite> Favourites { get; set; }
        public string[] ChartLabels { get; set; }
        public int[] BarChartData { get; set; }
        public int[] PieChartData { get; set; }
    }
}
