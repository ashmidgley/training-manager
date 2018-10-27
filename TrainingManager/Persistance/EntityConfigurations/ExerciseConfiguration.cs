using TrainingManager.Models;
using System.Data.Entity.ModelConfiguration;

namespace TrainingManager.Persistance.EntityConfigurations
{
    public class ExerciseConfiguration : EntityTypeConfiguration<Exercise>
    {
        public ExerciseConfiguration()
        {
            Property(e => e.WorkoutId)
               .IsRequired();

            Property(e => e.Name)
              .IsRequired()
              .HasMaxLength(255);

            Property(e => e.Reps)
                .IsRequired();

            Property(e => e.Sets)
                .IsRequired();
        }
    }
}
