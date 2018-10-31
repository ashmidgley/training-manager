using TrainingManager.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace TrainingManager.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index(string id = null)
        {
            if (id == null)
            {
                id = User.Identity.GetUserId();
            }

            var user = _unitOfWork.Users.GetUser(id);
            var imageSrc = _unitOfWork.TrainingTypes.GetFileName(user.TrainingTypeId);
            var plans = _unitOfWork.Plans.GetUserPlans(id);
            var ratings = _unitOfWork.Ratings.GetUserRatings(id);
            var favourites = _unitOfWork.Favourites.GetUserFavourites(id);

            //CHARTS
            var count = plans.Count();
            string[] labels = new string[count];
            int[] barData = new int[count];
            int[] pieData = new int[count];

            for (int i = 0; i < count; i++)
            {
                labels[i] = plans.ElementAt(i).Name;
                barData[i] = _unitOfWork.Favourites.GetNumberOfFavourites(plans.ElementAt(i).Id);
                pieData[i] = _unitOfWork.Plans.GetPlan(plans.ElementAt(i).Id).Views;
            }

            UserViewModel model = new UserViewModel
            {
                Header = user.Name,
                User = user,
                TrainingTypeFileName = imageSrc,
                Plans = plans,
                PlanCount = plans.Count(),
                Ratings = ratings,
                Favourites = favourites,
                ChartLabels = labels,
                BarChartData = barData,
                PieChartData = pieData
            };

            return View("Index", model);
        }

        [Authorize]
        public ActionResult All()
        {
            var users = _unitOfWork.Users.GetUsers();
            DateTime curr = DateTime.Now;
            var lineChartData = _unitOfWork.Views.GetPreviousWeekViews();
            var chartLabels = new string[7];
            for (int i = 0; i < 7; i++)
            {
                chartLabels[i] = curr.AddDays((i+1) - 7).DayOfWeek.ToString();
            }

            var model = new UsersViewModel
            {
                Header = "All Users",
                Users = users,
                ChartLabels = chartLabels,
                LineChartData = lineChartData
            };

            return View("All", model);
        }
    }
}