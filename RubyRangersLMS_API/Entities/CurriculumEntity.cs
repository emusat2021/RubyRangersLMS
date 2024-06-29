﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RubyRangersLMS_API.Entities
{
    public abstract class CurriculumEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

// All DataAnnotations removed for debugging (and entitytype and docucuments)
//public abstract class CurriculumEntity
//{
//    public Guid Id { get; set; }

//    [Required]
//    [StringLength(15, ErrorMessage = "Name is required (up to 15 characters)")]
//    public string Name { get; set; }
//    public string? Description { get; set; }

//    [Required]
//    [DataType(DataType.Date)]
//    [Display(Name = "Starting date")]
//    public DateTime StartDate { get; set; }

//    [DataType(DataType.Date)]
//    [Display(Name = "Ending date")]
//    public DateTime EndDate { get; set; }
//    public string EntityType { get; set; }

//    [NotMapped]
//    public ICollection<Document> OwnedDocuments { get; set; }
//}
