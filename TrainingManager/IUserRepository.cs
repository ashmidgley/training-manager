using TrainingManager.Models;
using System.Collections.Generic;

namespace TrainingManager
{
    public interface IUserRepository
    {
        ApplicationUser GetUser(string id);
        IEnumerable<ApplicationUser> GetUsers();
    }
}
