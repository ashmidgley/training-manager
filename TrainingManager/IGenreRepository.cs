using TrainingManager.Models;
using System.Collections.Generic;

namespace TrainingManager
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetGenres();
    }
}
