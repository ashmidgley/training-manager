using LiftManager.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LiftManager.Repositories
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
                .Include(p => p.Lifter)
                .ToList();
        }

        public IEnumerable<Plan> GetFavouritePlans(string userId)
        {
            return _context.Favourites
                .Where(a => a.FavouriterId == userId)
                .Select(a => a.Plan)
                .Include(g => g.Lifter)
                .ToList();
        }

        public IEnumerable<Plan> GetFilteredPlans(string query)
        {
            return _context.Plans
                    .Where(p => (p.Name.Contains(query) ||
                    p.Lifter.Name.Contains(query)) && !p.IsRemoved)
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
                .SingleOrDefault(p => p.Id == id && p.LifterId == userId);
        }

        public IEnumerable<Plan> GetUserPlans(string userId)
        {
            return _context.Plans
                .Where(g => g.Lifter.Id == userId && !g.IsRemoved)
                .ToList();
        }

        public void IncrementPlanViews(int planId)
        {
            var plan = _context.Plans
                .SingleOrDefault(p => p.Id == planId);
            plan.Views += 1;
        }
    }
}
