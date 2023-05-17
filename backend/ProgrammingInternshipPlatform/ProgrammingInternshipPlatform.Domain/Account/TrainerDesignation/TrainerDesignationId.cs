namespace ProgrammingInternshipPlatform.Domain.Account.TrainerDesignation;

public readonly struct TrainerDesignationId : IEquatable<TrainerDesignationId>
{
    public TrainerDesignationId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; }

    public bool Equals(TrainerDesignationId other)
    {
        return Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        return obj is TrainerDesignationId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(TrainerDesignationId left, TrainerDesignationId right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(TrainerDesignationId left, TrainerDesignationId right)
    {
        return !left.Equals(right);
    }
}