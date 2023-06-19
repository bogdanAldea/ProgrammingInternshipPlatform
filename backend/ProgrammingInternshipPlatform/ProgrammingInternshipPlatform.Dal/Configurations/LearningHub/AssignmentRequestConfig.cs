using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.Curriculum.Assignments;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Interns;
using ProgrammingInternshipPlatform.Domain.LearningHub.AssignmentRequests;
using ProgrammingInternshipPlatform.Domain.LearningHub.ScheduledPresentations;

namespace ProgrammingInternshipPlatform.Dal.Configurations.LearningHub;

public class AssignmentRequestConfig : IEntityTypeConfiguration<AssignmentRequest>
{
    public void Configure(EntityTypeBuilder<AssignmentRequest> builder)
    {
        builder.HasKey(request => request.AssignmentRequestId);

        builder
            .Property(request => request.AssignmentRequestId)
            .HasConversion(
                id => id.Value,
                value => new AssignmentRequestId(value))
            .IsRequired();
        
        builder
            .Property(request => request.ScheduledPresentationId)
            .HasConversion(
                id => id.Value,
                value => new ScheduledPresentationId(value))
            .IsRequired();
        
        builder
            .Property(request => request.AssignmentId)
            .HasConversion(
                id => id.Value,
                value => new AssignmentId(value))
            .IsRequired();
        
        builder
            .Property(request => request.InternId)
            .HasConversion(
                id => id.Value,
                value => new InternId(value))
            .IsRequired();

        builder
            .HasMany(request => request.Comments)
            .WithOne()
            .HasForeignKey(comment => comment.AssignmentRequestId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}