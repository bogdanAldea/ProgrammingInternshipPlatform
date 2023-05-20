using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.Curriculum.Lessons;
using ProgrammingInternshipPlatform.Domain.LearningHub.AssignmentRequests;
using ProgrammingInternshipPlatform.Domain.LearningHub.ScheduledPresentations;

namespace ProgrammingInternshipPlatform.Dal.Configurations.LearningHub;

public class ScheduledPresentationConfig : IEntityTypeConfiguration<ScheduledPresentation>
{
    public void Configure(EntityTypeBuilder<ScheduledPresentation> builder)
    {
        builder.HasIndex(presentation => presentation.ScheduledPresentationId);

        builder
            .Property(presentation => presentation.ScheduledPresentationId)
            .HasConversion(
                id => id.Value,
                value => new ScheduledPresentationId(value))
            .IsRequired();
        
        builder
            .Property(presentation => presentation.LessonId)
            .HasConversion(
                id => id.Value,
                value => new LessonId(value))
            .IsRequired();

        builder
            .HasOne(presentation => presentation.AssignmentRequest)
            .WithOne()
            .HasForeignKey<AssignmentRequest>(assignmentRequest => assignmentRequest.ScheduledPresentationId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Property(presentation => presentation.Status)
            .HasConversion(
                status => (int)status,
                value => (PresentationStatus)value)
            .IsRequired();
    }
}