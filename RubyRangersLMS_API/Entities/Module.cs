namespace RubyRangersLMS_API.Entities
{
    public class Module : CurriculumEntity
    {
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
    }
}
