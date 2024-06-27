namespace RubyRangersLMS_API.Entities
{
    public class Course : CurriculumEntity
    {
        public Guid TeacherId { get; set; }
        public List<Module> Modules { get; internal set; }
    }
}