using TrainingManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace TrainingManager.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly ApplicationDbContext _context;

        public ExerciseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Exercise exercise)
        {
            _context.Exercises.Add(exercise);
        }

        public bool ExerciseExists(int exerciseId)
        {
            return _context.Exercises
                .Any(e => e.Id == exerciseId);
        }

        public Exercise GetExercise(int id)
        {
            return _context.Exercises
                .SingleOrDefault(e => e.Id == id);
        }

        public IEnumerable<Exercise> GetExercises(int workoutId)
        {
            return _context.Exercises
                    .Where(e => e.WorkoutId == workoutId && !e.IsRemoved)
                    .ToList();
        }
    }
}
