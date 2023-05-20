using ProgrammingInternshipPlatform.Domain.Backlog.Stages;
using ProgrammingInternshipPlatform.Domain.ProjectHub.WorkItems;

namespace ProgrammingInternshipPlatform.Domain.Backlog.Cards;

public class Card
{
    private static readonly CardValidator CardValidator = new();
    public CardId CardId { get; private set; }
    public StageId StageId { get; private set; }
    public WorkItemId WorkItemId { get; private set; }
    public CardStatus Status { get; private set; } = CardStatus.NotStarted;

    public static async Task<Card> CreateNew(StageId stageId, WorkItemId workItemId, CancellationToken cancellationToken)
    {
        var cardToCreate = new Card
        {
            CardId = new CardId(Guid.NewGuid()),
            StageId = stageId,
            WorkItemId = workItemId
        };
        await CardValidator.ValidateDomainModelAsync(cardToCreate, cancellationToken);
        return cardToCreate;
    }
}