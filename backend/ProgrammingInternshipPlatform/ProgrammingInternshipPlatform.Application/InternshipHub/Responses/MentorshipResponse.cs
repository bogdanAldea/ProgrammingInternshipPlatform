using ProgrammingInternshipPlatform.Application.Abstractions.GraphApi.Responses;

namespace ProgrammingInternshipPlatform.Application.InternshipHub.Responses;

public class MentorshipResponse
{
    public Guid MentorshipId { get; init; }
    public Account Trainer { get; init; } = null!;
    public Account Intern { get; init; } = null!;
}