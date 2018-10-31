using TrainingManager.Models;
using System.Collections.Generic;

namespace TrainingManager.Repositories
{
    public interface IRatingRepository
    {
        void Add(Rating rating);
        void Remove(Rating rating);
        bool PlanHasRatings(int planId);
        bool UserRatingExists(string userId, int planId);
        double GetRatingAverage(int planId);
        int GetRatingCount(int planId);
        Rating GetUserRating(string userId, int planId);
        IEnumerable<Rating> GetPlanRatings(int planId);
        IEnumerable<Rating> GetUserRatings(string userId);
    }
}
