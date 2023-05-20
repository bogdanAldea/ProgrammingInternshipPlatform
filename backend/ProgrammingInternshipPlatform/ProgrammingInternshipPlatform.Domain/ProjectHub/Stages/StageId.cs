namespace ProgrammingInternshipPlatform.Domain.ProjectHub.Stages;

public readonly struct StageId : IEquatable<StageId>
{
    public StageId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; }

    public bool Equals(StageId other)
    {
        return Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        return obj is StageId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(StageId left, StageId right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(StageId left, StageId right)
    {
        return !left.Equals(right);
    }
}