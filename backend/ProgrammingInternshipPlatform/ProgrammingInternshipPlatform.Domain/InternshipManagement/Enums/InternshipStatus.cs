using System.ComponentModel.DataAnnotations;

namespace ProgrammingInternshipPlatform.Domain.InternshipManagement.Enums;

public enum InternshipStatus
{
    [Display(Name = "Setup in Progress", Description = "Indicates that the logistics for the internship is still in progress.")]
    SetupInProgress = 1,
    
    [Display(Name = "Ready To Start", Description = "Indicates that the internship has not yet started, but the setup is completed and can be started.")]
    ReadyToStart = 2,
    
    [Display(Name = "Ongoing", Description = "Indicates that the internship is currently in progress.")]
    Ongoing = 3,
    
    [Display(Name = "Completed", Description = "Indicates that the internship has been completed.")]
    Completed = 4
}