using LiftManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace LiftManager.Repositories
{
    public class LifterTypeRepository : ILifterTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public LifterTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public string GetFileName(byte id)
        {
            return _context.LifterTypes
                .SingleOrDefault(l => l.Id == id)
                .FileName;
        }

        public IEnumerable<LifterType> GetLifterTypes()
        {
            return _context.LifterTypes
                .ToList();
        }

        public string GetType(byte id)
        {
            LifterType type = _context.LifterTypes
                .SingleOrDefault(l => l.Id == id);
            return type.Name;
        }
    }
}
