using TrainingManager.Models;
using TrainingManager.ViewModels;
using Microsoft.AspNet.Identity;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace TrainingManager.Controllers
{
    public class ExercisesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExercisesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        public ActionResult Create(int workoutId, int planId)
        {
            var viewModel = new ExerciseFormViewModel
            {
                WorkoutId = workoutId,
                PlanId = planId
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExerciseFormViewModel viewModel)
        {
            //var imageTypes = new string[]{
            //        "image/gif",
            //        "image/jpeg",
            //        "image/pjpeg",
            //        "image/png"
            //};

            //if (viewModel.ImageUpload != null && !imageTypes.Contains(viewModel.ImageUpload.ContentType))
            //{
            //    ModelState.AddModelError("ImageUpload", "Please choose either a GIF, JPG or PNG image.");
            //}

            if (!ModelState.IsValid)
            {
                return View("Create", viewModel);
            }

            var userId = User.Identity.GetUserId();

            //byte[] image = null;
            //if (viewModel.ImageUpload != null)
            //{
            //    using (var ms = new MemoryStream())
            //    {
            //        viewModel.ImageUpload.InputStream.CopyTo(ms);
            //        image = ms.ToArray();
            //    }
            //}

            var exercise = new Exercise
            {
                WorkoutId = viewModel.WorkoutId,
                UserId = userId,
                Name = viewModel.Name,
                Duration = viewModel.Duration,
                Reps = viewModel.Reps == null ? "" : viewModel.Reps,
                Sets = viewModel.Sets == null ? "" : viewModel.Sets,
                Image = null,
                Comment = viewModel.Comment
            };

            _unitOfWork.Exercises.Add(exercise);
            _unitOfWork.Complete();

            return RedirectToAction("Summary", "Plans", new { Id = viewModel.PlanId });
        }
    }
}
