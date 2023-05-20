namespace ProgrammingInternshipPlatform.Domain.LearningHub.AssignmentRequests;

public readonly struct AssignmentRequestId : IEquatable<AssignmentRequestId>
{
    public AssignmentRequestId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; }

    public bool Equals(AssignmentRequestId other)
    {
        return Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        return obj is AssignmentRequestId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(AssignmentRequestId left, AssignmentRequestId right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(AssignmentRequestId left, AssignmentRequestId right)
    {
        return !left.Equals(right);
    }
}