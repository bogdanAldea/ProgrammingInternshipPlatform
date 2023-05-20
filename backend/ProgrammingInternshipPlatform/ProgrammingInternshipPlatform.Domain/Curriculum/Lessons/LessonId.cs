namespace ProgrammingInternshipPlatform.Domain.Curriculum.Lessons;

public readonly struct LessonId : IEquatable<LessonId>
{
    public LessonId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; }

    public bool Equals(LessonId other)
    {
        return Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        return obj is LessonId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(LessonId left, LessonId right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(LessonId left, LessonId right)
    {
        return !left.Equals(right);
    }
}