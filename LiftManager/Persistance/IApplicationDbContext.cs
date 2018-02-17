using LiftManager.Models;
using System.Data.Entity;

namespace LiftManager.Persistance
{
    public interface IApplicationDbContext
    {
        DbSet<Plan> Plans { get; set; }
        DbSet<Workout> Workouts { get; set; }
        DbSet<Exercise> Exercises { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Favourite> Favourites { get; set; }
        DbSet<Rating> Ratings { get; set; }
        IDbSet<ApplicationUser> Users { get; set; }
        void SaveChanges();
    }
}
