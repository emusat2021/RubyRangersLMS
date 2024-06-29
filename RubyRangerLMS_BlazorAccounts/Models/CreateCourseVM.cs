using System.ComponentModel.DataAnnotations;

namespace RubyRangerLMS_BlazorAccounts.Models
{
    public class CreateCourseVM
    {
        [Required]
        public Guid TeacherId { get; set; }

        [Required]
        [Display(Name = "Course Name")]
        [DataType(DataType.Text)]
        [StringLength(32, ErrorMessage = "Course Name needs to be between 2 - 32 Characters.", MinimumLength = 2)]
        public string Name { get; set; }

        [Display(Name = "Course Description")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}
