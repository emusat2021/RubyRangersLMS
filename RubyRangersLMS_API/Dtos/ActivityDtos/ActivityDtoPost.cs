using RubyRangersLMS_API.Entities;
using System.ComponentModel.DataAnnotations;

namespace RubyRangersLMS_API.Dtos.ActivityDtos
{
    public class ActivityDtoPost : CurriculumEntity
    {
        [Required]
        public int ModuleId { get; set; }
    }
}