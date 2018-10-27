using TrainingManager.Models;
using System.Collections.Generic;

namespace TrainingManager.Repositories
{
    public interface IWorkoutRepository
    {
        void Add(Workout workout);
        Workout GetUserWorkout(string userId, int workoutId);
        IEnumerable<Workout> GetWorkouts(int planId);
    }
}
