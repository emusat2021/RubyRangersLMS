using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RubyRangersLMS_API.Entities;
using RubyRangersLMS_API.IRepositories;
using RubyRangersLMS_API.Dtos.ModuleDtos;

namespace RubyRangersLMS_API.Dtos.CourseDtos
{
    public class CourseDtoGet : CurriculumEntity
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid CourseId { get; set; }
        [Required]
        public Guid TeacherId { get; set; }
        [Required]
        public List<ModuleDtoGet> Modules { get; set; }
    }
}