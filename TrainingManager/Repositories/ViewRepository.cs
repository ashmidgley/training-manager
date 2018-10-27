using TrainingManager.Models;
using System;
using System.Linq;

namespace TrainingManager.Repositories
{
    public class ViewRepository : IViewRepository
    {
        private readonly ApplicationDbContext _context;

        public ViewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(View view)
        {
            _context.Views
                .Add(view);
        }

        public int[] GetPreviousWeekViews()
        {
            var dateIndex = DateTime.Now.AddDays(-7); //Current date minus 7 days
            var values = new int[7];
            for (int i = 0; i < values.Length; i++)
            {
                var maxDate = dateIndex.AddDays(1);
                values[i] = _context.Views
                    .Where(v => v.Time > dateIndex && v.Time < maxDate)
                    .Count();
                dateIndex = dateIndex.AddDays(1);
            }
            return values;
        }
    }
}
