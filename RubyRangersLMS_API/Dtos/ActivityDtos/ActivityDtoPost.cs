using RubyRangersLMS_API.Entities;
using System.ComponentModel.DataAnnotations;

namespace RubyRangersLMS_API.Dtos.ActivityDtos
{
    public class ActivityDtoPost : CurriculumEntity
    {
        [Required]
        public Guid ModuleId { get; set; }
    }
}