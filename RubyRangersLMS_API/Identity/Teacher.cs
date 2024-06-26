using Microsoft.AspNetCore.Identity;
using RubyRangersLMS_API.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace RubyRangersLMS_API.Identity
{
    public class Teacher : ApplicationUser
    {
        public ICollection<Course> Courses { get; set; }
        [NotMapped]
        public ICollection<Document> OwnedDocuments { get; set; }
    }
}