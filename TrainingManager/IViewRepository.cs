using TrainingManager.Models;

namespace TrainingManager
{
    public interface IViewRepository
    {
        void Add(View view);
        int[] GetPreviousWeekViews();
    }
}
