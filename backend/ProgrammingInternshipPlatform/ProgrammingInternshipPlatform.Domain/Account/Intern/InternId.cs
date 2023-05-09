namespace ProgrammingInternshipPlatform.Domain.Account.Intern;

public struct InternId : IEquatable<InternId>
{
    public InternId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; set; }

    public bool Equals(InternId other)
    {
        return Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        return obj is InternId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(InternId left, InternId right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(InternId left, InternId right)
    {
        return !left.Equals(right);
    }
}