using System.ComponentModel.DataAnnotations;

namespace ProgrammingInternshipPlatform.Domain.Internships.Enums;

public enum InternshipStatus
{
    [Display(Name = "Not Started", Description = "Indicates that the internship has not yet started.")]
    NotStarted = 1,
    
    [Display(Name = "Ongoing", Description = "Indicates that the internship is currently in progress.")]
    Ongoing = 2,
    
    [Display(Name = "Completed", Description = "Indicates that the internship has been completed.")]
    Completed = 3
}