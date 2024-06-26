using System.ComponentModel.DataAnnotations;

namespace RubyRangersLMS_API.Entities
{
    public class Document
    {
        public Guid DocumentId { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Document name is required (up to 15 characters)")]
        public string DocumentName { get; set; }
        public string? DocumentDescription { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Uploaded")]
        public DateTime DocumentTimeStamp { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public byte[] DocumentByte { get; set; }

        // Navigation property: Course/Module/Activity.
        // This can be NULL, equals that it is a "general" file not related to a Course/Module/Activity. 
        public virtual CurriculumEntity AttachedToCurriculumEntity { get; set; }

        // The spcific owner of the file. StudenId or TeacherId is stored here.
        [Required]
        public Guid OwnedByUserId { get; set; }
    }
}