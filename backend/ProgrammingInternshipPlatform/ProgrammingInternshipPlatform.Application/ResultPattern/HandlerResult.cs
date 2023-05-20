namespace ProgrammingInternshipPlatform.Application.ResultPattern;

public class HandlerResult<TEntity>
{
    private HandlerResult() { }
    private HandlerResult(ApplicationError failureReason)
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
    public ApplicationError FailureReason { get; } = null!;
    public bool IsSuccess { get; set; }

    public static HandlerResult<TEntity> Fail(ApplicationError failureReason) => new(failureReason);
    public static HandlerResult<TEntity> Success(TEntity payload) => new(payload);
    public static HandlerResult<TEntity> Success() => new();
}