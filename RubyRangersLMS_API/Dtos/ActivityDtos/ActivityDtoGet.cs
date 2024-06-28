using RubyRangersLMS_API.Entities;
using System.ComponentModel.DataAnnotations;

namespace RubyRangersLMS_API.Dtos.ActivityDtos
{
    public class ActivityDtoGet : CurriculumEntity
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid ModuleId { get; set; }
    }
}
