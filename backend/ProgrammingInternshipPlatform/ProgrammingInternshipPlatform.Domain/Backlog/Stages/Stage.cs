using ProgrammingInternshipPlatform.Domain.Backlog.Boards;
using ProgrammingInternshipPlatform.Domain.Backlog.Cards;
using ProgrammingInternshipPlatform.Domain.ProjectHub.WorkItems;

namespace ProgrammingInternshipPlatform.Domain.Backlog.Stages;

public class Stage
{
    private static readonly StageValidator StageValidator = new();
    private readonly List<Card> _cards = new();

    public Stage() {}
    
    public StageId StageId { get; private set; }
    public BoardId BoardId { get; private set; }
    public string Title { get; private set; } = null!;
    public int Order { get; private set; }
    public IReadOnlyCollection<Card> Cards => _cards;

    public static async Task<Stage> CreateNew(BoardId boardId, string title, int order, CancellationToken cancellationToken)
    {
        var stageToCreate = new Stage
        {
            StageId = new StageId(Guid.NewGuid()),
            BoardId = boardId,
            Title = title,
            Order = order
        };
        await StageValidator.ValidateDomainModelAsync(stageToCreate, cancellationToken);
        return stageToCreate;
    }

    public async Task ChangeTitle(string newTitle, CancellationToken cancellationToken)
    {
        Title = newTitle;
        await StageValidator.ValidateDomainModelAsync(this, cancellationToken);
    }

    public async Task ChangeOrder(int newOrder, CancellationToken cancellationToken)
    {
        Order = newOrder;
        await StageValidator.ValidateDomainModelAsync(this, cancellationToken);
    }

    public async Task AddNewCard(WorkItemId workItemId, CancellationToken cancellationToken)
    {
        var cardToAdd = await Card.CreateNew(StageId, workItemId, cancellationToken);
        _cards.Add(cardToAdd);
        await StageValidator.ValidateDomainModelAsync(this, cancellationToken);
    }
}