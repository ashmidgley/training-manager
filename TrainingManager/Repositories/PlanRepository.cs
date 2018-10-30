using TrainingManager.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace TrainingManager.Repositories
{
    public class PlanRepository : IPlanRepository
    {
        private readonly ApplicationDbContext _context;

        public PlanRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Plan plan)
        {
            _context.Plans.Add(plan);
        }

        public IEnumerable<Plan> GetAllPlans()
        {
            return _context.Plans
                .Where(p => !p.IsRemoved)
                .Include(p => p.User)
                .ToList();
        }

        public IEnumerable<Plan> GetFavouritePlans(string userId)
        {
            return _context.Favourites
                .Where(a => a.FavouriterId == userId)
                .Select(a => a.Plan)
                .Include(g => g.User)
                .ToList();
        }

        public IEnumerable<Plan> GetFilteredPlans(string query)
        {
            return _context.Plans
                    .Where(p => (p.Name.Contains(query) ||
                    p.User.Name.Contains(query)) && !p.IsRemoved)
                    .ToList();
        }

        public Plan GetPlan(int planId)
        {
            return _context.Plans
                        .Where(p => p.Id == planId && !p.IsRemoved)
                        .SingleOrDefault();
        }

        public Plan GetUserPlan(int id, string userId)
        {
            return _context.Plans
                .SingleOrDefault(p => p.Id == id && p.UserId == userId);
        }

        public IEnumerable<Plan> GetUserPlans(string userId)
        {
            return _context.Plans
                .Where(g => g.User.Id == userId && !g.IsRemoved)
                .ToList();
        }

        public void IncrementPlanViews(int planId)
        {
            var plan = _context.Plans
                .SingleOrDefault(p => p.Id == planId);
            plan.Views += 1;
        }

        public void AddNewRating(int planId, double currentRating)
        {
            var plan = _context.Plans
                .SingleOrDefault(p => p.Id == planId);
            plan.Rating = currentRating;
            plan.RatingCount += 1;
        }

        public void UpdateRating(int planId, double currentRating)
        {
            var plan = _context.Plans
                .SingleOrDefault(p => p.Id == planId);
            plan.Rating = currentRating;
        }

        public void DeleteRating(int planId, double currentRating)
        {
            var plan = _context.Plans
                .SingleOrDefault(p => p.Id == planId);
            plan.Rating = currentRating;
            plan.RatingCount -= 1;
        }
    }
}
