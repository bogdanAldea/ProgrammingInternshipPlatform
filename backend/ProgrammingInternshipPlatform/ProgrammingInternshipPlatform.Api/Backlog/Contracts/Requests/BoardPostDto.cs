namespace ProgrammingInternshipPlatform.Api.Backlog.Contracts.Requests;

public class BoardPostDto
{
    public BoardPostDto(Guid projectId, Guid internId)
    {
        ProjectId = projectId;
        InternId = internId;
    }
    public Guid ProjectId { get; }
    public Guid InternId { get; }
}