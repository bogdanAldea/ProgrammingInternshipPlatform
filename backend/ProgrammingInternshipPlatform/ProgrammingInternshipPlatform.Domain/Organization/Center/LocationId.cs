namespace ProgrammingInternshipPlatform.Domain.Organization.Center;

public struct LocationId : IEquatable<LocationId>
{
    public LocationId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; set; }

    public bool Equals(LocationId other)
    {
        return Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        return obj is LocationId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(LocationId left, LocationId right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(LocationId left, LocationId right)
    {
        return !left.Equals(right);
    }
}