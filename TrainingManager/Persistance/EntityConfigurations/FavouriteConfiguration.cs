using TrainingManager.Models;
using System.Data.Entity.ModelConfiguration;

namespace TrainingManager.Persistance.EntityConfigurations
{
    public class FavouriteConfiguration : EntityTypeConfiguration<Favourite>
    {
        public FavouriteConfiguration()
        {
            HasRequired(f => f.Plan)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
    }
}
