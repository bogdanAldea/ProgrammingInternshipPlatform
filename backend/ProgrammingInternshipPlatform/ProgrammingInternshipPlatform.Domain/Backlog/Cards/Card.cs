using ProgrammingInternshipPlatform.Domain.Backlog.Stages;
using ProgrammingInternshipPlatform.Domain.ProjectHub.WorkItems;

namespace ProgrammingInternshipPlatform.Domain.Backlog.Cards;

public class Card
{
    public CardId CardId { get; private set; }
    public StageId StageId { get; private set; }
    public WorkItemId WorkItemId { get; private set; }
    public CardStatus Status { get; private set; } = CardStatus.NotStarted;
}