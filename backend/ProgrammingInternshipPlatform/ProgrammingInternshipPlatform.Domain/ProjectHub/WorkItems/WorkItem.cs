using ProgrammingInternshipPlatform.Domain.Backlog.Cards.Labels;
using ProgrammingInternshipPlatform.Domain.ProjectHub.AcceptanceCriteria;
using ProgrammingInternshipPlatform.Domain.ProjectHub.Projects;

namespace ProgrammingInternshipPlatform.Domain.ProjectHub.WorkItems;

public class WorkItem
{
    private readonly List<AcceptanceCriterion> _acceptanceCriteria = new();
    public WorkItemId WorkItemId { get; private set; }
    public ProjectId ProjectId { get; set; }
    public WorkItemStatus Status { get; private set; }
    public string Title { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public DateTime AddedOn { get; private set; }
    public DateTime? Deadline { get; private set; }
    public Item Item { get; private set; }
    public Priority Priority { get; private set; }
    public Complexity Complexity { get; private set; }
    public Risk? RiskLabel { get; private set; }
    public IReadOnlyCollection<AcceptanceCriterion> AcceptanceCriteria => _acceptanceCriteria;
}