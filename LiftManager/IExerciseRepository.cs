using LiftManager.Models;
using System.Collections.Generic;

namespace LiftManager.Repositories
{
    public interface IExerciseRepository
    {
        void Add(Exercise exercise);
        bool ExerciseExists(int exerciseId);
        Exercise GetExercise(int exerciseId);
        IEnumerable<Exercise> GetExercises(int workoutId);
    }
}
