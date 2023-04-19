namespace ProgrammingInternshipPlatform.Domain.InternshipManagement.Identifiers;

public struct TimeframeId : IEquatable<TimeframeId>
{
    public TimeframeId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; set; }

    public bool Equals(TimeframeId other)
    {
        return Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        return obj is TimeframeId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(TimeframeId left, TimeframeId right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(TimeframeId left, TimeframeId right)
    {
        return !left.Equals(right);
    }
}