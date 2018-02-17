using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace LiftManager.Controllers.Api
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

            if (plan.LifterId != userId)
                return Unauthorized();

            plan.Remove();

            _unitOfWork.Complete();

            return Ok();
        }
    }
}
