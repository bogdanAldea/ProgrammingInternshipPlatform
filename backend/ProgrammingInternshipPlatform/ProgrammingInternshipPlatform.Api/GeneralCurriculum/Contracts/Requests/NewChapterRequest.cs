using System.ComponentModel.DataAnnotations;

namespace ProgrammingInternshipPlatform.Api.GeneralCurriculum.Contracts.Requests;

public class NewChapterRequest
{
    [Required]
    public string TItle { get; set; }

    [Required]
    public string Description { get; set; }
}