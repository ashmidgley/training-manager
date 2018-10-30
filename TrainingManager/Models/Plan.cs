using System;
using System.Collections.Generic;

namespace TrainingManager.Models
{
    public class Plan
    {
        public int Id { get; set; }
        public bool IsRemoved { get; set; }
        public string Name { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public int LengthInWeeks { get; set; }
        public IEnumerable<Workout> Workouts { get; set; }
        public DateTime DateCreated { get; set; }
        public Double? Rating { get; set; }
        public int? RatingCount { get; set; }
        public int Views { get; set; }

        public void Remove()
        {
            IsRemoved = true;
        }
    }
}
