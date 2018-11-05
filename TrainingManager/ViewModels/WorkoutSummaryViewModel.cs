using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingManager.Models;

namespace TrainingManager.ViewModels
{
    public class WorkoutSummaryViewModel
    {
        public int PlanId { get; set; }
        public Workout Workout { get; set; }
        public IEnumerable<Exercise> Exercises { get; set; }
        public bool CanEdit { get; set; }
    }
}