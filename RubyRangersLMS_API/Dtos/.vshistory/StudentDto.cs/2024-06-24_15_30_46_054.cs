namespace RubyRangersLMS_API.Dtos
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public virtual string? Email { get; set; }
        public virtual bool EmailConfirmed { get; set; }
        public virtual string? PhoneNumber { get; set; }
        public virtual bool PhoneNumberConfirmed { get; set; }
        public virtual bool TwoFactorEnabled { get; set; }
        public virtual bool LockoutEnabled { get; set; }
        public virtual int AccessFailedCount { get; set; }
    }
}
