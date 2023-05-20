using System.ComponentModel.DataAnnotations;

namespace ProgrammingInternshipPlatform.Domain.ProjectHub.Projects;

public enum ProjectStatus
{
    [Display(Name = "Not Started", Description = "The project is still being brainstormed by the intern.")]
    NotStarted = 0,
    [Display(Name = "Approved By Mentor", Description = "The project has been approved by the intern's mentor.")]
    ApprovedByMentor = 1,
    [Display(Name = "Completed", Description = "The project has reached the MVP state.")]
    Completed = 2
}