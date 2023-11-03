using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Assignments.Models;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Lessons.Models;
using ProgrammingInternshipPlatform.Domain.Shared.Validators;

namespace ProgrammingInternshipPlatform.Dal.Configurations.GeneralCurriculum;

public class AssignmentConfig : IEntityTypeConfiguration<Assignment>
{
    public void Configure(EntityTypeBuilder<Assignment> builder)
    {
        builder
            .ToTable(AggregatesToTableNames.CurriculumManagement.Assignments);
        
        builder
            .HasKey(assignment => assignment.AssignmentId);

        builder
            .Property(assignment => assignment.AssignmentId)
            .HasConversion(id => id.Value, 
                value => new AssignmentId(value))
            .IsRequired();

        builder
            .Property(assignment => assignment.LessonId)
            .HasConversion(id => id.Value, 
                value => new LessonId(value))
            .IsRequired();

        builder
            .Property(assignment => assignment.Title)
            .HasMaxLength(RuleConstants.GeneralCurriculum.AssignmentTitleMaxLength)
            .IsRequired();
        
        builder
            .Property(assignment => assignment.Description)
            .HasMaxLength(RuleConstants.GeneralCurriculum.AssignmentDescriptionMaxLength)
            .IsRequired();
    }
}