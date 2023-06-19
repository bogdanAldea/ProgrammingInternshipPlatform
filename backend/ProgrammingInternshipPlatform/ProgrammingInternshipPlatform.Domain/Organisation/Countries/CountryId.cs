namespace ProgrammingInternshipPlatform.Domain.Organisation.Countries;

public struct CountryId : IEquatable<CountryId>
{
    public CountryId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; set; }

    public bool Equals(CountryId other)
    {
        return Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        return obj is CountryId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(CountryId left, CountryId right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(CountryId left, CountryId right)
    {
        return !left.Equals(right);
    }
}