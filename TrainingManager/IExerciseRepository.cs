using TrainingManager.Models;
using System.Collections.Generic;

namespace TrainingManager.Repositories
{
    public interface IExerciseRepository
    {
        void Add(Exercise exercise);
        bool ExerciseExists(int exerciseId);
        Exercise GetExercise(int exerciseId);
        IEnumerable<Exercise> GetExercises(int workoutId);
    }
}
