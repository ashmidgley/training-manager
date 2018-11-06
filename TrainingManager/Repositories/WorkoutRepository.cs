using TrainingManager.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace TrainingManager.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly ApplicationDbContext _context;

        public WorkoutRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Workout workout)
        {
            _context.Workouts.Add(workout);
        }

        public Workout GetUserWorkout(string userId, int id)
        {
            return _context.Workouts
                .SingleOrDefault(w => w.Id == id && w.UserId == userId);
        }

        public Workout GetWorkout(int planId, int workoutId)
        {
            return _context.Workouts
                .SingleOrDefault(w => w.Id == workoutId && w.PlanId == planId);
        }

        public IEnumerable<Workout> GetWorkouts(int planId)
        {
            return _context.Workouts
                .Where(w => w.PlanId == planId && !w.IsRemoved)
                .Include(w => w.Genre)
                .ToList();
        }
    }
}
