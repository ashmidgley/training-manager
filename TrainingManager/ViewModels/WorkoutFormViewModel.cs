using Antlr.Runtime.Misc;
using TrainingManager.Controllers;
using TrainingManager.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace TrainingManager.ViewModels
{
    public class WorkoutFormViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public byte Genre { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        [Required]
        public int PlanId { get; set; }
        public string PlanName { get; set; }
        public IEnumerable<Plan> Plans { get; set; }
        public int Week { get; set; }
        public int Day { get; set; }
        public string Heading { get; set; }
        public string Action
        {
            get
            {
                Expression<Func<WorkoutsController, ActionResult>> update =
                    (c => c.Update(this));

                Expression<Func<WorkoutsController, ActionResult>> create =
                    (c => c.Create(this));

                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;

            }
        }
    }
}
