namespace ProgrammingInternshipPlatform.Domain.ProjectHub.WorkItems;

public readonly struct WorkItemId : IEquatable<WorkItemId>
{
    public WorkItemId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; }

    public bool Equals(WorkItemId other)
    {
        return Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        return obj is WorkItemId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(WorkItemId left, WorkItemId right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(WorkItemId left, WorkItemId right)
    {
        return !left.Equals(right);
    }
}