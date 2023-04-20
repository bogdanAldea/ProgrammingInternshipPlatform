namespace ProgrammingInternshipPlatform.Domain.Account.Identifiers;

public struct AccountId : IEquatable<AccountId>
{
    public AccountId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; set; }

    public bool Equals(AccountId other)
    {
        return Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        return obj is AccountId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(AccountId left, AccountId right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(AccountId left, AccountId right)
    {
        return !left.Equals(right);
    }
}