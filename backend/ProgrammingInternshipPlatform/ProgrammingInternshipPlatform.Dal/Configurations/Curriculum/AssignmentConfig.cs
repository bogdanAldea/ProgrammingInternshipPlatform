using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.Curriculum.Assignments;
using ProgrammingInternshipPlatform.Domain.Curriculum.Lessons;

namespace ProgrammingInternshipPlatform.Dal.Configurations.Curriculum;

public class AssignmentConfig : IEntityTypeConfiguration<Assignment>
{
    public void Configure(EntityTypeBuilder<Assignment> builder)
    {
        builder.HasIndex(assignment => assignment.AssignmentId);

        builder
            .Property(assignment => assignment.AssignmentId)
            .HasConversion(
                id => id.Value,
                value => new AssignmentId(value))
            .IsRequired();
        
        builder
            .Property(assignment => assignment.LessonId)
            .HasConversion(
                id => id.Value,
                value => new LessonId(value))
            .IsRequired();

        builder
            .Property(assignment => assignment.Description)
            .IsRequired();
    }
}