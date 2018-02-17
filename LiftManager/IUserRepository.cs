using LiftManager.Models;
using System.Collections.Generic;

namespace LiftManager
{
    public interface IUserRepository
    {
        ApplicationUser GetUser(string id);
        IEnumerable<ApplicationUser> GetUsers();
    }
}
