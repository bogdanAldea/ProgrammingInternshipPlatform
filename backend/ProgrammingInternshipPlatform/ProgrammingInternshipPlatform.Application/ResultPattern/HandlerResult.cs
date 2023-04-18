namespace ProgrammingInternshipPlatform.Application.ResultPattern;

public class HandlerResult<TEntity>
{
    private HandlerResult(string failureReason)
    {
        FailureReason = failureReason;
        IsSuccess = false;
    }

    private HandlerResult(TEntity payload)
    {
        Payload = payload;
        IsSuccess = true;
    }

    public TEntity? Payload { get; set; }
    public string? FailureReason { get; set; }
    public bool IsSuccess { get; set; }

    public static HandlerResult<TEntity> Fail(string failureReason) => new(failureReason);
    public static HandlerResult<TEntity> Success(TEntity payload) => new(payload);
}