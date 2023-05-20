namespace ProgrammingInternshipPlatform.Domain.ProjectHub.AcceptanceCriteria;

public readonly struct AcceptanceCriterionId : IEquatable<AcceptanceCriterionId>
{
    public AcceptanceCriterionId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; }

    public bool Equals(AcceptanceCriterionId other)
    {
        return Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        return obj is AcceptanceCriterionId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(AcceptanceCriterionId left, AcceptanceCriterionId right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(AcceptanceCriterionId left, AcceptanceCriterionId right)
    {
        return !left.Equals(right);
    }
}