using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace TrainingManager.Controllers.Api
{
    [Authorize]
    public class PlansController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlansController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpDelete]
        public IHttpActionResult Remove(int id)
        {
            var userId = User.Identity.GetUserId();
            var plan = _unitOfWork.Plans.GetPlan(id);

            if (plan == null || plan.IsRemoved)
                return NotFound();

            if (plan.UserId != userId)
                return Unauthorized();

            plan.Remove();

            _unitOfWork.Complete();

            return Ok();
        }
    }
}
