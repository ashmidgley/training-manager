using LiftManager.Models;

namespace LiftManager
{
    public interface IViewRepository
    {
        void Add(View view);
        int[] GetPreviousWeekViews();
    }
}
