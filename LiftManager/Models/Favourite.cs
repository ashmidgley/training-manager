using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiftManager.Models
{
    public class Favourite
    {
        public Plan Plan { get; set; }

        public ApplicationUser Favouriter { get; set; }

        [Key]
        [Column(Order = 1)]
        public int PlanId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string FavouriterId { get; set; }
    }
}
