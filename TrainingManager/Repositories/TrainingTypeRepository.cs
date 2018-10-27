using TrainingManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace TrainingManager.Repositories
{
    public class TrainingTypeRepository : ITrainingTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public TrainingTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public string GetFileName(byte id)
        {
            return _context.TrainingTypes
                .SingleOrDefault(l => l.Id == id)
                .FileName;
        }

        public IEnumerable<TrainingType> GetTrainingTypes()
        {
            return _context.TrainingTypes
                .ToList();
        }

        public string GetType(byte id)
        {
            TrainingType type = _context.TrainingTypes
                .SingleOrDefault(l => l.Id == id);
            return type.Name;
        }
    }
}
