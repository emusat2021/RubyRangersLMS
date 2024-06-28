using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace RubyRangersLMS_API.IRepositories
{
    // Not used at the moment
    public interface ICourseDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Name is required (up to 15 characters)")]
        public string Name { get; set; }
        public string? Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Starting date")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Ending date")]
        public DateTime EndDate { get; set; }
        [Required]
        public string EntityType { get; set; }

        [NotMapped]
        public ICollection<Document> OwnedDocuments { get; set; }
    }
}
