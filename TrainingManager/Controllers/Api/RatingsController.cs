using TrainingManager.Dtos;
using TrainingManager.Models;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace TrainingManager.Controllers.Api
{
    public class RatingsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public RatingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult Rate(RatingDto dto)
        {
            var userId = User.Identity.GetUserId();

            //rating exists
            if (_unitOfWork.Ratings.UserRatingExists(userId, dto.PlanId))
            {
                //PUT - Update value
                var currentRating = _unitOfWork.Ratings.GetUserRating(userId, dto.PlanId);
                currentRating.Value = dto.Value;

                _unitOfWork.Complete();

                return Ok();
            }

            var rater = User.Identity.GetUserName();

            var rating = new Rating
            {
                Plan = _unitOfWork.Plans.GetUserPlan(dto.PlanId, userId),
                Value = dto.Value,
                PlanId = dto.PlanId,
                RaterId = userId
            };

            _unitOfWork.Ratings.Add(rating);
            _unitOfWork.Complete();

            return Ok();
        }

        [Route("api/ratings/{planId}")]
        [HttpDelete]
        public IHttpActionResult DeleteRating(int planId)
        {
            var userId = User.Identity.GetUserId();
            var rating = _unitOfWork.Ratings.GetUserRating(userId, planId);

            if (rating == null)
            {
                return NotFound();
            }

            _unitOfWork.Ratings.Remove(rating);
            _unitOfWork.Complete();

            return Ok(planId);
        }
    }
}
