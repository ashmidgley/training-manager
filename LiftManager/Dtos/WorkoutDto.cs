using LiftManager.Models;
using System.Collections.Generic;

namespace LiftManager.Dtos
{
    public class WorkoutDto
    {
        public IEnumerable<Workout> Workouts { get; set; }
    }
}
