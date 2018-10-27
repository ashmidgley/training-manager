using System;
using System.Collections.Generic;

namespace TrainingManager.Models
{
    public class Plan
    {
        public int Id { get; set; }
        public bool IsRemoved { get; set; }
        public string Name { get; set; }
        public ApplicationUser Lifter { get; set; }
        public string LifterId { get; set; }
        public int LengthInWeeks { get; set; }
        public IEnumerable<Workout> Workouts { get; set; }
        public DateTime DateCreated { get; set; }
        public Double Rating { get; set; }
        public int Views { get; set; }

        public void Remove()
        {
            IsRemoved = true;
        }
    }
}
