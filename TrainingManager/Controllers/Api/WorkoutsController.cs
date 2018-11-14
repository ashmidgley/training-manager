using TrainingManager.Dtos;
using TrainingManager.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace TrainingManager.Controllers.Api
{
    public class WorkoutsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public WorkoutsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("api/workouts/{planId}")]
        public IHttpActionResult GetWorkouts(int planId)
        {
            IEnumerable<Workout> workouts = _unitOfWork.Workouts.GetWorkouts(planId);

            foreach (Workout w in workouts)
            {
                w.Exercises = _unitOfWork.Exercises.GetExercises(w.Id);
            }

            var workoutDto = new WorkoutDto
            {
                Workouts = workouts
            };

            return Ok(workoutDto);
        }
        
        [HttpGet]
        [Route("api/workouts/exercise-count/{workoutId}")]
        public IHttpActionResult GetExerciseCount(int workoutId)
        {
            int count = _unitOfWork.Exercises.GetExercises(workoutId).Count();
            return Ok(count);
        }

        [Authorize]
        [HttpDelete]
        [Route("api/workouts/{id}")]
        public IHttpActionResult Remove(int id)
        {
            var userId = User.Identity.GetUserId();
            var workout = _unitOfWork.Workouts.GetUserWorkout(userId, id);

            if (workout.IsRemoved)
            {
                return NotFound();
            }

            workout.IsRemoved = true;

            _unitOfWork.Complete();

            return Ok();
        }
    }
}
