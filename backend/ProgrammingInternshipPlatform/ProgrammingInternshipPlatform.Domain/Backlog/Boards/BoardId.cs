namespace ProgrammingInternshipPlatform.Domain.Backlog.Boards;

public readonly struct BoardId : IEquatable<BoardId>
{
    public BoardId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; }


    public bool Equals(BoardId other)
    {
        return Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        return obj is BoardId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(BoardId left, BoardId right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(BoardId left, BoardId right)
    {
        return !left.Equals(right);
    }
}