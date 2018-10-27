using System.ComponentModel.DataAnnotations;
using System.Web;

namespace TrainingManager.ViewModels
{
    public class ExerciseFormViewModel
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public string Duration { get; set; }
        public string Reps { get; set; }
        public string Sets { get; set; }
        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageUpload { get; set; }
        public string Comment { get; set; }
        [Required]
        public int WorkoutId { get; set; }
        [Required]
        public int PlanId { get; set; }
    }
}
