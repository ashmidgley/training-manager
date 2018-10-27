namespace TrainingManager.Models
{
    public class Exercise
    {
        public int Id { get; set; }

        public int WorkoutId { get; set; }

        public ApplicationUser Lifter { get; set; }

        public string LifterId { get; set; }

        public string Name { get; set; }

        public string Duration { get; set; }

        public string Reps { get; set; }

        public string Sets { get; set; }

        public byte[] Image { get; set; }

        public string Comment { get; set; }

        public bool IsRemoved { get; set; }
    }
}
