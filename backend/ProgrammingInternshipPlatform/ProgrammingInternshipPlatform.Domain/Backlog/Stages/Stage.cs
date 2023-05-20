using ProgrammingInternshipPlatform.Domain.Backlog.Boards;
using ProgrammingInternshipPlatform.Domain.Backlog.Cards;

namespace ProgrammingInternshipPlatform.Domain.Backlog.Stages;

public class Stage
{
    private readonly List<Card> _cards = new();

    public Stage() {}
    
    public StageId StageId { get; private set; }
    public BoardId BoardId { get; private set; }
    public string Title { get; private set; } = null!;
    public int Order { get; private set; }
    public IReadOnlyCollection<Card> Cards => _cards;
}