using LiftManager.Dtos;
using LiftManager.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Http;

namespace LiftManager.Controllers.Api
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
                CanEdit = (userId == exercise.LifterId && User.Identity.IsAuthenticated)
            };

            return Ok(exerciseDto);
        }

        [HttpPut]
        //[Route("api/exercises/{exerciseId}")]
        public IHttpActionResult UpdateExerciseComment(Exercise dto)
        //public IHttpActionResult UpdateExerciseComment([FromUri] int exerciseId, string comment)
        {
            //{
            //    if (_unitOfWork.Exercises.ExerciseExists(exerciseId))
            //    {
            //        var currentExercise = _unitOfWork.Exercises.GetExercise(exerciseId);
            //        currentExercise.Comment = comment;
            if (_unitOfWork.Exercises.ExerciseExists(dto.Id))
            {
                var currentExercise = _unitOfWork.Exercises.GetExercise(dto.Id);
                currentExercise.Comment = dto.Comment;

                _unitOfWork.Complete();

                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("api/exercises/{exerciseId}")]
        public IHttpActionResult UpdateExerciseImage([FromUri] int exerciseId)
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var files = httpRequest.Files;
                var imageUpload = files[0];
                if (imageUpload != null && imageUpload.ContentLength > 0)
                {

                    int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB

                    IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png", ".jpeg" };
                    var ext = imageUpload.FileName.Substring(imageUpload.FileName.LastIndexOf('.'));
                    var extension = ext.ToLower();
                    if (!AllowedFileExtensions.Contains(extension))
                    {
                        //Not image
                        var message = string.Format("Please Upload image of type .jpg,.gif,.png.");
                    }
                    else if (imageUpload.ContentLength > MaxContentLength)
                    {
                        //Too big
                        var message = string.Format("Please Upload a file upto 1 mb.");
                    }
                    else
                    {
                        //Convert file upload to byte array
                        byte[] image = null;
                        using (var ms = new MemoryStream())
                        {
                            imageUpload.InputStream.CopyTo(ms);
                            image = ms.ToArray();
                        }
                        var currentExercise = _unitOfWork.Exercises.GetExercise(exerciseId);
                        currentExercise.Image = image;

                        _unitOfWork.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok();
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
