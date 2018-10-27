using TrainingManager.Models;
using TrainingManager.Repositories;

namespace TrainingManager.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IPlanRepository Plans { get; private set; }
        public IWorkoutRepository Workouts { get; private set; }
        public IExerciseRepository Exercises { get; private set; }
        public IFavouriteRepository Favourites { get; private set; }
        public IGenreRepository Genres { get; private set; }
        public IRatingRepository Ratings { get; private set; }
        public ILifterTypeRepository LifterTypes { get; set; }
        public IUserRepository Users { get; set; }
        public IViewRepository Views { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Plans = new PlanRepository(context);
            Workouts = new WorkoutRepository(context);
            Exercises = new ExerciseRepository(context);
            Favourites = new FavouriteRepository(context);
            Genres = new GenreRepository(context);
            Ratings = new RatingRepository(context);
            LifterTypes = new LifterTypeRepository(context);
            Users = new UserRepository(context);
            Views = new ViewRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
