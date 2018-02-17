using LiftManager.Models;
using System.Collections.Generic;

namespace LiftManager
{
    public interface ILifterTypeRepository
    {
        string GetType(byte id);
        string GetFileName(byte id);
        IEnumerable<LifterType> GetLifterTypes();
    }
}
