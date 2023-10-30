using ProgrammingInternshipPlatform.Application.ResultPattern.FailureReason;
using ProgrammingInternshipPlatform.Application.ResultPattern.SuccessResult;

namespace ProgrammingInternshipPlatform.Application.ResultPattern;

public class HandlerResult<TPayload, TFailure>
{
    private HandlerResult()
    {
        IsSuccess = true;
    }
    private HandlerResult(FailureReason<TFailure> failureReason)
    {
        FailureReason = failureReason;
        IsSuccess = false;
    }
    
    private HandlerResult(SuccessResult.SuccessResult successResult)
    {
        SuccessResult = successResult;
        IsSuccess = true;
    }

    private HandlerResult(SuccessResult<TPayload> successResult)
    {
        SuccessResultWithPayload = successResult;
        IsSuccess = true;
    }

    public SuccessResult<TPayload>? SuccessResultWithPayload { get; }
    public SuccessResult.SuccessResult? SuccessResult { get; }
    public FailureReason<TFailure>? FailureReason { get; }
    public bool IsSuccess { get; set; }

    public static HandlerResult<TPayload, TFailure> NotFoundFailure(TFailure failureReason)
        => new(FailureReason<TFailure>.NotFoundFailure(failureReason));

    public static HandlerResult<TPayload, TFailure> InternalServerFailure(TFailure failureReason)
        => new(FailureReason<TFailure>.InternalServerFailure(failureReason));
    
    public static HandlerResult<TPayload, TFailure> DomainValidationFailure(TFailure failureReason)
        => new(FailureReason<TFailure>.DomainValidationFailure(failureReason));

    public static HandlerResult<TPayload, TFailure> ReadSuccessful(TPayload payload)
        => new(SuccessResult<TPayload>.ReadSuccessful(payload));
    
    public static HandlerResult<TPayload, TFailure> CreateSuccessful(TPayload payload)
        => new(SuccessResult<TPayload>.CreateSuccessful(payload));
    
    public static HandlerResult<TPayload, TFailure> UpdateSuccessfulWithPayload(TPayload payload)
        => new(SuccessResult<TPayload>.UpdateSuccessful(payload));

    public static HandlerResult<TPayload, TFailure> UpdateSuccessful()
        => new(ResultPattern.SuccessResult.SuccessResult.UpdateSuccessful());

    public static HandlerResult<TPayload, TFailure> DeleteSuccessful()
        => new(ResultPattern.SuccessResult.SuccessResult.DeleteSuccessful());
}