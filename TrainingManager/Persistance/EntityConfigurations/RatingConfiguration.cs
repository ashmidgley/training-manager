using TrainingManager.Models;
using System.Data.Entity.ModelConfiguration;

namespace TrainingManager.Persistance.EntityConfigurations
{
    public class RatingConfiguration : EntityTypeConfiguration<Rating>
    {
        public RatingConfiguration()
        {
            Property(r => r.Value)
                .IsRequired();

            HasRequired(r => r.Plan)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
    }
}
