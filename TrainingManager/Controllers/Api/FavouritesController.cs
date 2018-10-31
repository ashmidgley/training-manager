using TrainingManager.Dtos;
using TrainingManager.Models;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace TrainingManager.Controllers
{
    [Authorize]
    public class FavouritesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public FavouritesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult Favour(FavouriteDto dto)
        {
            var userId = User.Identity.GetUserId();
            var favouriteExists = _unitOfWork.Favourites.FavouriteExists(userId, dto.PlanId);

            if (favouriteExists)
            {
                return BadRequest("The Favourite instance already exists");
            }

            var favourite = new Favourite
            {
                PlanId = dto.PlanId,
                FavouriterId = userId
            };

            _unitOfWork.Favourites.Add(favourite);
            _unitOfWork.Complete();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteFavourite(int id)
        {
            var userId = User.Identity.GetUserId();
            var favourite = _unitOfWork.Favourites.GetUserFavourite(userId, id);

            if (favourite == null)
            {
                return NotFound();
            }

            _unitOfWork.Favourites.Remove(favourite);
            _unitOfWork.Complete();

            return Ok(id);
        }
    }
}
