namespace ProgrammingInternshipPlatform.Domain.Curriculum.Assignments;

public readonly struct AssignmentId : IEquatable<AssignmentId>
{
    public AssignmentId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; }

    public bool Equals(AssignmentId other)
    {
        return Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        return obj is AssignmentId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(AssignmentId left, AssignmentId right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(AssignmentId left, AssignmentId right)
    {
        return !left.Equals(right);
    }
}