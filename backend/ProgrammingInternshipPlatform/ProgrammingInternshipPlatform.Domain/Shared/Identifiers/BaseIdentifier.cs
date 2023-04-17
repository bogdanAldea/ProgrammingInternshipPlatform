namespace ProgrammingInternshipPlatform.Domain.Shared.Identifiers;

public class BaseIdentifier : IEquatable<BaseIdentifier>
{
    protected BaseIdentifier(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public bool Equals(BaseIdentifier? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((BaseIdentifier)obj);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(BaseIdentifier? left, BaseIdentifier? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(BaseIdentifier? left, BaseIdentifier? right)
    {
        return !Equals(left, right);
    }
}