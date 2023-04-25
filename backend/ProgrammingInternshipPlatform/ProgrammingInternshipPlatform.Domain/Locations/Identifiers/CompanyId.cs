namespace ProgrammingInternshipPlatform.Domain.Locations.Identifiers;

public class CompanyId : IEquatable<CompanyId>
{
    public Guid Value { get; }

    public CompanyId(Guid value)
    {
        Value = value;
    }

    public bool Equals(CompanyId? other)
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
        return Equals((CompanyId)obj);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(CompanyId? left, CompanyId? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(CompanyId? left, CompanyId? right)
    {
        return !Equals(left, right);
    }
}