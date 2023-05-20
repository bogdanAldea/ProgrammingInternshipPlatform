namespace ProgrammingInternshipPlatform.Domain.Curriculum.Modules;

public readonly struct ModuleId : IEquatable<ModuleId>
{
    public ModuleId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; }

    public bool Equals(ModuleId other)
    {
        return Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        return obj is ModuleId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(ModuleId left, ModuleId right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(ModuleId left, ModuleId right)
    {
        return !left.Equals(right);
    }
}