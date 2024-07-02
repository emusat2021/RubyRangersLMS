using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace RubyRangersLMS_API.Entities
{
    public class Student : IdentityUser
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }

        [NotMapped]
        public ICollection<Document> OwnedDocuments { get; set; }
    }
}
