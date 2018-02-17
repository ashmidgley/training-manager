using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiftManager.Models
{
    public class Rating
    {
        public Plan Plan { get; set; }

        public ApplicationUser Rater { get; set; }

        public int Value { get; set; }

        [Key]
        [Column(Order = 1)]
        public int PlanId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string RaterId { get; set; }
    }
}
