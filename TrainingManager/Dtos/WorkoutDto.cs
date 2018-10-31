using TrainingManager.Models;
using System.Collections.Generic;

namespace TrainingManager.Dtos
{
    public class WorkoutDto
    {
        public IEnumerable<Workout> Workouts { get; set; }
    }
}
