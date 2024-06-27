namespace RubyRangersLMS_API.Entities
{
    public class Module : CurriculumEntity
    {
        public Guid CourseId { get; set; }
        public List<Activity> Activities { get; internal set; }
    }
}
