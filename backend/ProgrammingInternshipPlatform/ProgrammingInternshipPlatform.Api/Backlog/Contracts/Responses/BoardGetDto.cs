using ProgrammingInternshipPlatform.Domain.Backlog.Boards;

namespace ProgrammingInternshipPlatform.Api.Backlog.Contracts.Responses;

public class BoardGetDto
{
    public Guid BoardId { get; private set; }
    public Guid ProjectId { get; private set; }
    public Guid OwnerIntern { get; private set; }
    public string Title { get; private set; } = null!;

    public static BoardGetDto MapFromBoard(Board board)
    {
        return new BoardGetDto
        {
            BoardId = board.BoardId.Value,
            ProjectId = board.ProjectId.Value,
            OwnerIntern = board.OwnerIntern.Value,
            Title = board.Title
        };
    }
}