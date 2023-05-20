namespace ProgrammingInternshipPlatform.Domain.ProjectHub.Cards;

public readonly struct CardId : IEquatable<CardId>
{
    public CardId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; }

    public bool Equals(CardId other)
    {
        return Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        return obj is CardId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(CardId left, CardId right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(CardId left, CardId right)
    {
        return !left.Equals(right);
    }
}