namespace ProgrammingInternshipPlatform.Domain.InternshipManagement.Internship;

public struct InternshipId : IEquatable<InternshipId>
{
    public InternshipId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; set; }

    public bool Equals(InternshipId other)
    {
        return Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        return obj is InternshipId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(InternshipId left, InternshipId right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(InternshipId left, InternshipId right)
    {
        return !left.Equals(right);
    }
}