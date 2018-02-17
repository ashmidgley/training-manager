using LiftManager.Models;
using LiftManager.ViewModels;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace LiftManager.Controllers
{
    public class WorkoutsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public WorkoutsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        public ActionResult Create(int planId, int week, int day)
        {
            var userId = User.Identity.GetUserId();

            var planName = _unitOfWork.Plans.GetPlan(planId).Name;

            var viewModel = new WorkoutFormViewModel
            {
                Genres = _unitOfWork.Genres.GetGenres(),
                Plans = _unitOfWork.Plans.GetUserPlans(userId),
                Heading = "Create a Workout",
                PlanId = planId,
                PlanName = planName,
                Week = week,
                Day = day
            };

            return View("WorkoutForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkoutFormViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();

            if (!ModelState.IsValid)
            {
                viewModel.Genres = _unitOfWork.Genres.GetGenres();
                //viewModel.Plans = _unitOfWork.Plans.GetUserPlans(userId);
                return View("WorkoutForm", viewModel);
            }

            var workout = new Workout
            {
                PlanId = viewModel.PlanId,
                LifterId = userId,
                GenreId = viewModel.Genre,
                Name = viewModel.Name,
                Week = viewModel.Week,
                Day = viewModel.Day
            };

            _unitOfWork.Workouts.Add(workout);
            _unitOfWork.Complete();

            return RedirectToAction("Summary", "Plans", new { Id = viewModel.PlanId });
        }

        [Authorize]
        public ActionResult Edit(int planId, int workoutId)
        {
            var userId = User.Identity.GetUserId();
            var plan = _unitOfWork.Plans.GetUserPlan(planId, userId);
            var workout = _unitOfWork.Workouts.GetUserWorkout(userId, workoutId);

            if (workout == null)
            {
                return View("Workout not found!");
            }

            var viewModel = new WorkoutFormViewModel
            {
                Id = workoutId,
                Name = workout.Name,
                Genre = workout.GenreId,
                Genres = _unitOfWork.Genres.GetGenres(),
                PlanId = planId,
                PlanName = plan.Name,
                Heading = "Edit Workout"
            };

            return View("WorkoutForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(WorkoutFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("WorkoutForm", viewModel);
            }

            var userId = User.Identity.GetUserId();
            var workout = _unitOfWork.Workouts.GetUserWorkout(userId, viewModel.Id);

            workout.Name = viewModel.Name;
            workout.GenreId = viewModel.Genre;

            _unitOfWork.Complete();

            return RedirectToAction("Summary", "Plans", new { Id = workout.PlanId });
        }
    }
}
