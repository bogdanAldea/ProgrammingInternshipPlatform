using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.LearningHub.AssignmentRequests;
using ProgrammingInternshipPlatform.Domain.LearningHub.Comments;

namespace ProgrammingInternshipPlatform.Dal.Configurations.LearningHub;

public class CommentConfig : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasIndex(comment => comment.CommentId);

        builder
            .Property(comment => comment.CommentId)
            .HasConversion(
                id => id.Value,
                value => new CommentId(value))
            .IsRequired();
        
        builder
            .Property(comment => comment.AssignmentRequestId)
            .HasConversion(
                id => id.Value,
                value => new AssignmentRequestId(value))
            .IsRequired();

        builder
            .Property(comment => comment.Message)
            .IsRequired();
    }
}