using RubyRangersLMS_API.Entities;
using System.ComponentModel.DataAnnotations;

namespace RubyRangersLMS_API.ViewModels
{
    public class TeacherViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

    }
}
