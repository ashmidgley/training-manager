using LiftManager.Models;
using System.Collections.Generic;

namespace LiftManager
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetGenres();
    }
}
