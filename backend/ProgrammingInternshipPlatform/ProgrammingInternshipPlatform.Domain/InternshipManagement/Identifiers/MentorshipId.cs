namespace ProgrammingInternshipPlatform.Domain.InternshipManagement.Identifiers;

public struct MentorshipId : IEquatable<MentorshipId>
{
    public MentorshipId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; set; }

    public bool Equals(MentorshipId other)
    {
        return Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        return obj is MentorshipId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(MentorshipId left, MentorshipId right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(MentorshipId left, MentorshipId right)
    {
        return !left.Equals(right);
    }
}