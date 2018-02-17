using LiftManager.Models;
using System.Collections.Generic;

namespace LiftManager.Repositories
{
    public interface IPlanRepository
    {
        void Add(Plan plan);
        void IncrementPlanViews(int planId);
        Plan GetPlan(int planId);
        Plan GetUserPlan(int planId, string userId);
        IEnumerable<Plan> GetAllPlans();
        IEnumerable<Plan> GetUserPlans(string userId);
        IEnumerable<Plan> GetFilteredPlans(string query);
        IEnumerable<Plan> GetFavouritePlans(string userId);


    }
}
