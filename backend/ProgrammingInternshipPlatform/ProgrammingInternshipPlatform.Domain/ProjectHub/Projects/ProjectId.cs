namespace ProgrammingInternshipPlatform.Domain.ProjectHub.Projects;

public readonly struct ProjectId : IEquatable<ProjectId>
{
    public ProjectId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; }

    public bool Equals(ProjectId other)
    {
        return Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        return obj is ProjectId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(ProjectId left, ProjectId right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(ProjectId left, ProjectId right)
    {
        return !left.Equals(right);
    }
}