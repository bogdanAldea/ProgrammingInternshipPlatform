using System.ComponentModel.DataAnnotations;

namespace ProgrammingInternshipPlatform.Api.Controllers.Requests;

public class NewTopicRequest
{
    [Required] public string Title { get; set; }
    [Required] public string Description { get; set; }
}