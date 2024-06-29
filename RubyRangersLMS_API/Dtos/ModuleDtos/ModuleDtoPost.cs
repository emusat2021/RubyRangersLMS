using RubyRangersLMS_API.Dtos.ActivityDtos;
using RubyRangersLMS_API.Entities;
using System.ComponentModel.DataAnnotations;

namespace RubyRangersLMS_API.Dtos.ModuleDtos
{
    public class ModuleDtoPost : CurriculumEntity
    {
        [Required]
        public ICollection<ActivityDtoPost> Activities { get; set; } = new List<ActivityDtoPost>();
    }
}