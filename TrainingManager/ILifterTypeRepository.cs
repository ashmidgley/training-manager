using TrainingManager.Models;
using System.Collections.Generic;

namespace TrainingManager
{
    public interface ILifterTypeRepository
    {
        string GetType(byte id);
        string GetFileName(byte id);
        IEnumerable<LifterType> GetLifterTypes();
    }
}
