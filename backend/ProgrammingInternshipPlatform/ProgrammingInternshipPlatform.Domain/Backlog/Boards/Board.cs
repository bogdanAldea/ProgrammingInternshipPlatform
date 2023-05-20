using ProgrammingInternshipPlatform.Domain.Backlog.Stages;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Interns;
using ProgrammingInternshipPlatform.Domain.ProjectHub.Projects;
using ProgrammingInternshipPlatform.Domain.ProjectHub.WorkItems;

namespace ProgrammingInternshipPlatform.Domain.Backlog.Boards;

public class Board
{
    private static readonly BoardValidator BoardValidator = new();
    private readonly List<Stage> _stages = new();

    public BoardId BoardId { get; private set; }
    public ProjectId ProjectId { get; private set; }
    public InternId OwnerIntern { get; private set; }
    public string Title { get; private set; } = null!;
    public IReadOnlyCollection<Stage> Stages => _stages;

    public static async Task<Board> CreateNew(ProjectId projectId, InternId ownerIntern, string projectTitle,
        CancellationToken cancellationToken)
    {
        var boardToCreate = new Board
        {
            BoardId = new BoardId(Guid.NewGuid()),
            ProjectId = projectId,
            OwnerIntern = ownerIntern,
            Title = $"{projectTitle} Backlog"
        };
        await BoardValidator.ValidateDomainModelAsync(boardToCreate, cancellationToken);
        return boardToCreate;
    }

    public async Task AddStage(string title, int? order, CancellationToken cancellationToken)
    {
        order ??= _stages.Count + 1;
        var stageToAdd = await Stage.CreateNew(BoardId, title, (int)order, cancellationToken);
        _stages.Add(stageToAdd);
        await BoardValidator.ValidateDomainModelAsync(this, cancellationToken);
    }

    public async Task RemoveStage(StageId stageId, CancellationToken cancellationToken)
    {
        var stageToRemove = _stages.FirstOrDefault(stage => stage.StageId == stageId);
        if (stageToRemove != null) _stages.Remove(stageToRemove);
        await BoardValidator.ValidateDomainModelAsync(this, cancellationToken);
    }

    public async Task ChangeStageTitle(StageId stageId, string newTitle, CancellationToken cancellationToken)
    {
        var stageToUpdateTitleTo = _stages.FirstOrDefault(stage => stage.StageId == stageId);
        if (stageToUpdateTitleTo != null) await stageToUpdateTitleTo.ChangeTitle(newTitle, cancellationToken);
        await BoardValidator.ValidateDomainModelAsync(this, cancellationToken);
    }

    public async Task AddCard(StageId stageId, WorkItemId workItemId, CancellationToken cancellationToken)
    {
        var stageToAddCardTo = _stages.FirstOrDefault(stage => stage.StageId == stageId);
        if (stageToAddCardTo is not null) await stageToAddCardTo.AddNewCard(workItemId, cancellationToken);
        await BoardValidator.ValidateDomainModelAsync(this, cancellationToken);
    }
}