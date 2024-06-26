using RubyRangersLMS_API.Identity;

namespace RubyRangersLMS_API.Entities
{
    public class Course : CurriculumEntity
    {
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public List<Module> Modules { get; internal set; }
    }
}