namespace ProgrammingInternshipPlatform.Domain.Account.Trainer;

public readonly struct TrainerId : IEquatable<TrainerId>
{
    public TrainerId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; }

    public bool Equals(TrainerId other)
    {
        return Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        return obj is TrainerId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(TrainerId left, TrainerId right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(TrainerId left, TrainerId right)
    {
        return !left.Equals(right);
    }
}