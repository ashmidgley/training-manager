using System.Collections.Generic;

namespace LiftManager.Models
{
    public class Workout
    {
        public int Id { get; set; }

        public bool IsRemoved { get; set; }

        public int PlanId { get; set; }

        public ApplicationUser Lifter { get; set; }

        public string LifterId { get; set; }

        public Genre Genre { get; set; }

        public byte GenreId { get; set; }

        public string Name { get; set; }
        public int Week { get; set; }
        public int Day { get; set; }

        public IEnumerable<Exercise> Exercises { get; set; }
    }
}
