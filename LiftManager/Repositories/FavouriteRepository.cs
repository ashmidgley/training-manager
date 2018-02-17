using LiftManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace LiftManager.Repositories
{
    public class FavouriteRepository : IFavouriteRepository
    {
        private readonly ApplicationDbContext _context;

        public FavouriteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Favourite favourite)
        {
            _context.Favourites.Add(favourite);
        }

        public bool FavouriteExists(string userId, int planId)
        {
            return _context.Favourites
                   .Any(a => a.FavouriterId == userId && a.PlanId == planId);
        }

        public Favourite GetUserFavourite(string userId, int planId)
        {
            return _context.Favourites
                .SingleOrDefault(f => f.FavouriterId == userId && f.PlanId == planId);
        }

        public IEnumerable<Favourite> GetUserFavourites(string userId)
        {
            return _context.Favourites
                .Where(f => f.FavouriterId == userId)
                .ToList();
        }

        public int GetNumberOfFavourites(int planId)
        {
            return _context.Favourites
                .Count(f => f.PlanId == planId);
        }

        public void Remove(Favourite favourite)
        {
            _context.Favourites.Remove(favourite);
        }
    }
}
