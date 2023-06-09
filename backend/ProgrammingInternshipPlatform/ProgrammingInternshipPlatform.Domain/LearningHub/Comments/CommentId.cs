﻿namespace ProgrammingInternshipPlatform.Domain.LearningHub.Comments;

public readonly struct CommentId : IEquatable<CommentId>
{
    public CommentId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; }

    public bool Equals(CommentId other)
    {
        return Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        return obj is CommentId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(CommentId left, CommentId right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(CommentId left, CommentId right)
    {
        return !left.Equals(right);
    }
}