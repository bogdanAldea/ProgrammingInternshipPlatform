namespace ProgrammingInternshipPlatform.Application.ResultPattern;

public class HandlerResult<TEntity>
{
    private HandlerResult()
    {
        IsSuccess = true;
    }
    private HandlerResult(FailureReason failureReason)
    {
        FailureReason = failureReason;
        IsSuccess = false;
    }

    private HandlerResult(TEntity payload)
    {
        Payload = payload;
        IsSuccess = true;
    }

    public TEntity? Payload { get; }
    public FailureReason FailureReason { get; } = null!;
    public bool IsSuccess { get; set; }

    public static HandlerResult<TEntity> Fail(FailureReason failureReason) => new(failureReason);
    public static HandlerResult<TEntity> Success(TEntity payload) => new(payload);
    public static HandlerResult<TEntity> Success() => new();
}