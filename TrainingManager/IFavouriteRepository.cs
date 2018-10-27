using TrainingManager.Models;
using System.Collections.Generic;

namespace TrainingManager.Repositories
{
    public interface IFavouriteRepository
    {
        void Add(Favourite favourite);
        void Remove(Favourite favourite);
        bool FavouriteExists(string userId, int planId);
        int GetNumberOfFavourites(int planId);

        Favourite GetUserFavourite(string userId, int planId);
        IEnumerable<Favourite> GetUserFavourites(string userId);
    }
}
