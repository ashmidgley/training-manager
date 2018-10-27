using TrainingManager.Models;
using System.Data.Entity.ModelConfiguration;

namespace TrainingManager.Persistance.EntityConfigurations
{
    public class WorkoutConfiguration : EntityTypeConfiguration<Workout>
    {
        public WorkoutConfiguration()
        {
            Property(w => w.PlanId)
                .IsRequired();

            Property(w => w.LifterId)
                .IsRequired();

            Property(w => w.GenreId)
                .IsRequired();

            Property(w => w.Name)
                 .IsRequired()
                 .HasMaxLength(255);
        }
    }
}
