using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.Accounts.Identifiers;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Assignment.Identifiers;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Assignment.Model;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Lesson.Identifier;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.ValidationConstants;

namespace ProgrammingInternshipPlatform.Dal.Configurations.GeneralCurriculum;

public class AssignmentConfig : IEntityTypeConfiguration<Assignment>
{
    public void Configure(EntityTypeBuilder<Assignment> builder)
    {
        builder
            .HasKey(assignment => assignment.AssignmentId);

        builder
            .Property(assignment => assignment.AssignmentId)
            .HasConversion(id => id.Value, 
                value => new AssignmentId(value))
            .IsRequired();
        
        builder
            .Property(assignment => assignment.LastUpdatedByAccount)
            .HasConversion(id => id.Value, 
                value => new AccountId(value))
            .IsRequired();
        
        builder
            .Property(assignment => assignment.LessonId)
            .HasConversion(id => id.Value, 
                value => new LessonId(value))
            .IsRequired();

        builder
            .Property(assignment => assignment.Title)
            .HasMaxLength(ChapterValidationConstants.AssignmentTitleLength)
            .IsRequired();
        
        builder
            .Property(assignment => assignment.Description)
            .HasMaxLength(ChapterValidationConstants.AssignmentDescriptionLength)
            .IsRequired();
    }
}