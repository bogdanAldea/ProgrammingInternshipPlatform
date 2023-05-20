namespace ProgrammingInternshipPlatform.Domain.LearningHub.ScheduledPresentations;

public readonly struct ScheduledPresentationId : IEquatable<ScheduledPresentationId>
{
    public ScheduledPresentationId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; }

    public bool Equals(ScheduledPresentationId other)
    {
        return Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        return obj is ScheduledPresentationId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(ScheduledPresentationId left, ScheduledPresentationId right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(ScheduledPresentationId left, ScheduledPresentationId right)
    {
        return !left.Equals(right);
    }
}