namespace RubyRangersLMS_API.Entities;
using RubyRangerLMS_BlazorAccounts.Models;
using System.Reflection.Metadata;

public class CreateCourse
{
    public Guid TeacherId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}