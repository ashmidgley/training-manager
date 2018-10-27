using TrainingManager.Models;
using System.Data.Entity.ModelConfiguration;

namespace TrainingManager.Persistance.EntityConfigurations
{
    public class PlanConfiguration : EntityTypeConfiguration<Plan>
    {
        public PlanConfiguration()
        {
            Property(p => p.Name)
               .IsRequired()
               .HasMaxLength(255);

            Property(p => p.LifterId)
                .IsRequired();
        }
    }
}
