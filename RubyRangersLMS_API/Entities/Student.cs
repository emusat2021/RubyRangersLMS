using Microsoft.AspNetCore.Identity;

namespace RubyRangersLMS_API.Entities
{
    public class Student : IdentityUser
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public ICollection<Document> OwnedDocuments { get; set; }
    }
}
