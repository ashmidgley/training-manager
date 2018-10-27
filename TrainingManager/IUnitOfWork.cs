using TrainingManager.Repositories;

namespace TrainingManager
{
    public interface IUnitOfWork
    {
        IPlanRepository Plans { get; }
        IWorkoutRepository Workouts { get; }
        IExerciseRepository Exercises { get; }
        IFavouriteRepository Favourites { get; }
        IGenreRepository Genres { get; }
        IRatingRepository Ratings { get; }
        ITrainingTypeRepository TrainingTypes { get; }
        IUserRepository Users { get; }
        IViewRepository Views { get; }
        void Complete();
    }
}
