using RubyRangersLMS_API.Dtos.ActivityDtos;
using RubyRangersLMS_API.Dtos.ModuleDtos;
using RubyRangersLMS_API.Entities;
using System.ComponentModel.DataAnnotations;

namespace RubyRangersLMS_API.Dtos.CourseDtos
{
    public class CourseDtoPost : CurriculumEntity
    {
        [Required]
        public Guid TeacherId { get; set; }
        [Required]
        public ICollection<ModuleDtoPost> Modules { get; set; } = new List<ModuleDtoPost>();
    }
}