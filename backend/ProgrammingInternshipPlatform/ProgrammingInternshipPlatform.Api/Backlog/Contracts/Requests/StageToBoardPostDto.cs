namespace ProgrammingInternshipPlatform.Api.Backlog.Contracts.Requests;

public class StageToBoardPostDto
{
    public StageToBoardPostDto(string stageTitle, int? stageOrder)
    {
        StageTitle = stageTitle;
        StageOrder = stageOrder;
    }
    public string StageTitle { get; }
    public int? StageOrder { get; }
}