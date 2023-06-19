namespace ProgrammingInternshipPlatform.Domain.InternshipModule;

public struct InternshipModuleId : IEquatable<InternshipModuleId>
{
    public InternshipModuleId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; set; }

    public bool Equals(InternshipModuleId other)
    {
        return Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        return obj is InternshipModuleId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(InternshipModuleId left, InternshipModuleId right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(InternshipModuleId left, InternshipModuleId right)
    {
        return !left.Equals(right);
    }
}