using TrainingManager.Dtos;
using TrainingManager.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Http;

namespace TrainingManager.Controllers.Api
{
    public class ExercisesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExercisesController(IUnitOfWork unitofWork)
        {
            _unitOfWork = unitofWork;
        }

        [HttpGet]
        [Route("api/exercises/{exerciseId}")]
        public IHttpActionResult GetExercise(int exerciseId)
        {
            var userId = User.Identity.GetUserId();
            var exercise = _unitOfWork.Exercises.GetExercise(exerciseId);

            if (exercise.IsRemoved)
            {
                return NotFound();
            }

            var exerciseDto = new ExerciseDto
            {
                Exercise = exercise,
            };

            return Ok(exerciseDto);
        }

        [HttpDelete]
        [Route("api/exercises/{id}")]
        public IHttpActionResult Remove(int id)
        {
            var exercise = _unitOfWork.Exercises.GetExercise(id);

            if (exercise.IsRemoved)
            {
                return NotFound();
            }

            exercise.IsRemoved = true;
            _unitOfWork.Complete();

            return Ok();
        }
    }
}
