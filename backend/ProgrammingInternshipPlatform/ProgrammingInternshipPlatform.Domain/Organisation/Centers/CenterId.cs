namespace ProgrammingInternshipPlatform.Domain.Organisation.Centers;

public struct CenterId : IEquatable<CenterId>
{
    public CenterId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; set; }

    public bool Equals(CenterId other)
    {
        return Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        return obj is CenterId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(CenterId left, CenterId right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(CenterId left, CenterId right)
    {
        return !left.Equals(right);
    }
}