using ProgrammingInternshipPlatform.Domain.Backlog.Boards;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Interns;
using ProgrammingInternshipPlatform.Domain.ProjectHub.WorkItems;

namespace ProgrammingInternshipPlatform.Domain.ProjectHub.Projects;

public class Project
{
    private readonly List<WorkItem> _workItems = new();
    public Project() {}

    public ProjectId ProjectId { get; private set; }
    public InternId InternId { get; private set; }
    public ProjectStatus ProjectStatus { get; private set; } = ProjectStatus.NotStarted;
    public DateTime? StartedOn { get; private set; }
    public DateTime? CompletedOn { get; private set; }
    public Uri UrlLocation { get; private set; } = null!;
    public string Title { get; private set; } = null!;
    public string Documentation { get; private set; } = null!;
    public IReadOnlyCollection<WorkItem> WorkItems => _workItems;
}