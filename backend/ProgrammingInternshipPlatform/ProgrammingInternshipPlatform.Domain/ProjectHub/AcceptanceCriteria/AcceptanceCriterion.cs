using ProgrammingInternshipPlatform.Domain.ProjectHub.WorkItems;

namespace ProgrammingInternshipPlatform.Domain.ProjectHub.AcceptanceCriteria;

public class AcceptanceCriterion
{
    public AcceptanceCriterionId AcceptanceCriterionId { get; private set; }
    public WorkItemId WorkItemId { get; private set; }
    public MetCondition MetCondition { get; private set; }
    public string Description { get; private set; } = null!;
}