using ProgrammingInternshipPlatform.Domain.Backlog.Boards;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Interns;

namespace ProgrammingInternshipPlatform.Domain.ProjectHub.Projects;

public class Project
{
    public Project() {}

    public ProjectId ProjectId { get; private set; }
    public InternId InternId { get; private set; }
    public ProjectStatus ProjectStatus { get; private set; } = ProjectStatus.NotStarted;
    public Uri UrlLocation { get; private set; } = null!;
    public string Title { get; private set; } = null!;
    public string Documentation { get; private set; } = null!;
}