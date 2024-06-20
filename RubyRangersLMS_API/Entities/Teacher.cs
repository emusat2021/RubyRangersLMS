using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace RubyRangersLMS_API.Entities
{
    public class Teacher : IdentityUser
    {
        public Guid Id { get; set; }
        public ICollection<Course> Courses { get; set; }
        [NotMapped]
        public ICollection<Document> OwnedDocuments { get; set; }
    }
}
