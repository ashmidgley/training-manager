using TrainingManager.Models;
using System.Collections.Generic;

namespace TrainingManager
{
    public interface ITrainingTypeRepository
    {
        string GetType(byte id);
        string GetFileName(byte id);
        IEnumerable<TrainingType> GetTrainingTypes();
    }
}
