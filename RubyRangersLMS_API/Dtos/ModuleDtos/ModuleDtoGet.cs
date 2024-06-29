using RubyRangersLMS_API.Dtos.ActivityDtos;
using RubyRangersLMS_API.Entities;
using System.ComponentModel.DataAnnotations;

namespace RubyRangersLMS_API.Dtos.ModuleDtos
{
    public class ModuleDtoGet : CurriculumEntity
    {
        [Required]
        public Guid CourseId { get; set; }
        [Required]
        public List<ActivityDtoGet> Activities { get; set; }
    }
}