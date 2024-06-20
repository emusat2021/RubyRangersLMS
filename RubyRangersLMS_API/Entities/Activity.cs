namespace RubyRangersLMS_API.Entities
{
    public class Activity : CurriculumEntity
    {
        public Guid ModuleId { get; set; }
        public Module Module { get; set; }
    }
}
