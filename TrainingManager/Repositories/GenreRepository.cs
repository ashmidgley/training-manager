using TrainingManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingManager.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _context;

        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _context.Genres
                .ToList();
        }
    }
}