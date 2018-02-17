using LiftManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace LiftManager.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ApplicationUser GetUser(string id)
        {
            return _context.Users
                .Where(u => u.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<ApplicationUser> GetUsers()
        {
            return _context.Users
                .ToList();
        }
    }
}
