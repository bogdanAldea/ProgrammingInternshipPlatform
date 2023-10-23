namespace ProgrammingInternshipPlatform.Application.ResultPattern;

public class HandlerResult<TPayload, TFailure>
{
    private HandlerResult()
    {
        IsSuccess = true;
    }
    private HandlerResult(TFailure failureReason)
    {
        FailureReason = failureReason;
        IsSuccess = false;
    }

    private HandlerResult(TPayload payload)
    {
        Payload = payload;
        IsSuccess = true;
    }

    public TPayload? Payload { get; }
    public TFailure? FailureReason { get; }
    public bool IsSuccess { get; set; }

    public static HandlerResult<TPayload, TFailure> Fail(TFailure failureReason) => new(failureReason);
    public static HandlerResult<TPayload, TFailure> Success(TPayload payload) => new(payload);
    public static HandlerResult<TPayload, TFailure> Success() => new();
}