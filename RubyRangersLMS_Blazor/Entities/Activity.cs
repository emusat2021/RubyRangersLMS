namespace RubyRangersLMS_Blazor.Entities
{
    public class Activity : CurriculumEntity
    {
        public Guid ModuleId { get; set; }
        public Module Module { get; set; }
    }
}
