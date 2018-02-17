using LiftManager.Models;
using System.Data.Entity.ModelConfiguration;

namespace LiftManager.Persistance.EntityConfigurations
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
