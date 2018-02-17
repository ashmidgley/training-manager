using LiftManager.Repositories;

namespace LiftManager
{
    public interface IUnitOfWork
    {
        IPlanRepository Plans { get; }
        IWorkoutRepository Workouts { get; }
        IExerciseRepository Exercises { get; }
        IFavouriteRepository Favourites { get; }
        IGenreRepository Genres { get; }
        IRatingRepository Ratings { get; }
        ILifterTypeRepository LifterTypes { get; }
        IUserRepository Users { get; }
        IViewRepository Views { get; }
        void Complete();
    }
}
