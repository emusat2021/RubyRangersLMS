using Microsoft.AspNetCore.Identity;

namespace RubyRangersLMS_API.Entities
{
    public class Teacher : IdentityUser
    {
        public Guid Id { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Document> OwnedDocuments { get; set; }
    }
}
