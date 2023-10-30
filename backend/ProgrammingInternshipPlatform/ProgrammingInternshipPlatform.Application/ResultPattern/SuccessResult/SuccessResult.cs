namespace ProgrammingInternshipPlatform.Application.ResultPattern.SuccessResult;

public class SuccessResult
{
    protected SuccessResult(OperationType operationType)
    {
        OperationType = operationType;
        SuccessType = SuccessType.WithoutPayload;
    }
    
    public OperationType OperationType { get; }
    public SuccessType SuccessType { get; set; }

    public static SuccessResult UpdateSuccessful() => new(OperationType.Update);
    public static SuccessResult DeleteSuccessful() => new(OperationType.Update);
}

public class SuccessResult<TPayload> : SuccessResult
{
    private SuccessResult(TPayload payload, OperationType operationType) : base(operationType)
    {
        Payload = payload;
        SuccessType = SuccessType.WithPayload;
    }
    
    public TPayload Payload { get; }

    public static SuccessResult<TPayload> ReadSuccessful(TPayload payload) =>
        new(payload: payload, operationType: OperationType.Read);
    
    public static SuccessResult<TPayload> CreateSuccessful(TPayload payload) =>
        new(payload: payload, operationType: OperationType.Create);
    
    public static SuccessResult<TPayload> UpdateSuccessful(TPayload payload) =>
        new(payload: payload, operationType: OperationType.UpdateWithPayload);
    
}