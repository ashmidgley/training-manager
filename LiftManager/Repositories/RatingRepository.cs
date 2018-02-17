using LiftManager.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LiftManager.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly ApplicationDbContext _context;

        public RatingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public double GetRatingAverage(int planId)
        {
            if (PlanHasRatings(planId))
            {
                return _context.Ratings
                           .Where(r => r.PlanId == planId)
                           .Average(r => r.Value);
            }
            return 0.0;
        }

        public IEnumerable<Rating> GetPlanRatings(int planId)
        {
            return _context.Ratings
                .Where(r => r.PlanId == planId)
                .ToList();
        }

        public bool PlanHasRatings(int planId)
        {
            return _context.Ratings
                .Any(r => r.PlanId == planId);
        }

        public IEnumerable<Rating> GetUserRatings(string userId)
        {
            return _context.Ratings
                .Where(r => r.RaterId == userId)
                .Include(r => r.Plan)
                .ToList();
        }

        public bool UserRatingExists(string userId, int planId)
        {
            return _context.Ratings
                .Any(r => r.PlanId == planId && r.RaterId == userId);
        }

        public Rating GetUserRating(string userId, int planId)
        {
            return _context.Ratings
                    .SingleOrDefault(r => r.PlanId == planId && r.RaterId == userId);
        }

        public void Add(Rating rating)
        {
            _context.Ratings.Add(rating);
        }

        public void Remove(Rating rating)
        {
            _context.Ratings.Remove(rating);
        }

        public int GetRatingCount(int planId)
        {
            return _context.Ratings
                .Count(r => r.PlanId == planId);
        }
    }
}
