using LiftManager.Controllers;
using LiftManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace LiftManager.ViewModels
{
    public class PlansFormViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int PlanId { get; set; }
        [Range(1, 52, ErrorMessage = "Length of program must be between 1 and 52 weeks long.")]
        public int LengthInWeeks { get; set; }
        public string CreatedOn { get; set; }
        public int Favourites { get; set; }
        public double Rating { get; set; }
        public int RatingCount { get; set; }
        public int Views { get; set; }
        public int MyProperty { get; set; }
        public IEnumerable<Workout> Workouts { get; set; }
        [Required]
        public bool CanEdit { get; set; }
        public string Heading { get; set; }
        public string Action
        {
            get
            {
                Expression<Func<PlansController, ActionResult>> update =
                    (c => c.Update(this));

                Expression<Func<PlansController, ActionResult>> create =
                    (c => c.Create(this));

                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;

            }
        }

        public PlansFormViewModel()
        {
            LengthInWeeks = 1;
        }
    }
}
