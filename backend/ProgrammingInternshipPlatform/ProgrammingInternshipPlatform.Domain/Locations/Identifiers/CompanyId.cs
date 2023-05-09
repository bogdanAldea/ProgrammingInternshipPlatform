namespace ProgrammingInternshipPlatform.Domain.Locations.Identifiers;

public struct CompanyId : IEquatable<CompanyId>
{
    public Guid Value { get; }

    public CompanyId(Guid value)
    {
        Value = value;
    }


    public bool Equals(CompanyId other)
    {
        return Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        return obj is CompanyId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(CompanyId left, CompanyId right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(CompanyId left, CompanyId right)
    {
        return !left.Equals(right);
    }
}