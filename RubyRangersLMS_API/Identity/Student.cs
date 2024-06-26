using Microsoft.AspNetCore.Identity;
using RubyRangersLMS_API.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace RubyRangersLMS_API.Identity
{
    public class Student : ApplicationUser
    {
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        [NotMapped]
        public ICollection<Document> OwnedDocuments { get; set; }
    }
}