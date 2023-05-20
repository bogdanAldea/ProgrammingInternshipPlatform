using ProgrammingInternshipPlatform.Domain.ProjectHub.Cards.Labels;
using ProgrammingInternshipPlatform.Domain.ProjectHub.Stages;

namespace ProgrammingInternshipPlatform.Domain.ProjectHub.Cards;

public class Card
{
    public CardId CardId { get; private set; }
    public StageId StageId { get; private set; }
    public string Title { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public DateTime AddedOn { get; private set; }
    public DateTime? Deadline { get; private set; }
    public TypeLabel TypeLabel { get; private set; }
    public PriorityLabel PriorityLabel { get; private set; }
    public ComplexityLabel ComplexityLabel { get; private set; }
    public RiskLabel? RiskLabel { get; private set; }
}