using ProgrammingInternshipPlatform.Domain.ProjectHub.Boards;
using ProgrammingInternshipPlatform.Domain.ProjectHub.Cards;

namespace ProgrammingInternshipPlatform.Domain.ProjectHub.Stages;

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