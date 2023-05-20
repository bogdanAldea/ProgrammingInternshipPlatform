using ProgrammingInternshipPlatform.Domain.Backlog.Stages;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Interns;
using ProgrammingInternshipPlatform.Domain.ProjectHub.Projects;

namespace ProgrammingInternshipPlatform.Domain.Backlog.Boards;

public class Board
{
    private readonly List<Stage> _stages = new();
    
    public BoardId BoardId { get; private set; }
    public ProjectId ProjectId { get; private set; }
    public InternId OwnerIntern { get; private set; }
    public IReadOnlyCollection<Stage> Stages => _stages;
}