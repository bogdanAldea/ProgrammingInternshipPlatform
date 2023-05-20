using ProgrammingInternshipPlatform.Domain.Backlog.Cards.Labels;
using ProgrammingInternshipPlatform.Domain.Backlog.Stages;
using ProgrammingInternshipPlatform.Domain.ProjectHub.WorkItems;

namespace ProgrammingInternshipPlatform.Domain.Backlog.Cards;

public class Card
{
    public CardId CardId { get; private set; }
    public StageId StageId { get; private set; }
    public WorkItemId WorkItemId { get; private set; }
}