using LiftManager.Models;
using System.Collections.Generic;

namespace LiftManager.ViewModels
{
    public class UsersViewModel
    {
        public string Header { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
        public string[] ChartLabels { get; set; }
        public int[] LineChartData { get; set; }
    }
}
