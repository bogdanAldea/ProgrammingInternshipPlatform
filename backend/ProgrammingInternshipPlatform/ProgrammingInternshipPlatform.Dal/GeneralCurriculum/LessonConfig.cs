using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.Assignments.Models;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.Lessons.Models;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.Topics.Identifiers;
using ProgrammingInternshipPlatform.Domain.Shared.Validators;

namespace ProgrammingInternshipPlatform.Dal.GeneralCurriculum;

public class LessonConfig : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder
            .ToTable("Lessons");
        builder
            .HasKey(lesson => lesson.LessonId);
        
        builder
            .Property(lesson => lesson.LessonId)
            .HasConversion(id => id.Value, 
                value => new LessonId(value));
        
        builder
            .Property(lesson => lesson.TopicId)
            .HasConversion(id => id.Value, 
                value => new TopicId(value));

        builder
            .Property(lesson => lesson.Title)
            .HasMaxLength(RuleConstants.GeneralCurriculum.LessonTitleMaxLength);
        
        builder
            .Property(lesson => lesson.Description)
            .HasMaxLength(RuleConstants.GeneralCurriculum.LessonDescriptionMaxLength);

        builder
            .Property(lesson => lesson.TopicOrder)
            .IsRequired();

        builder
            .HasOne(lesson => lesson.Assignment)
            .WithOne()
            .HasForeignKey<Assignment>(assignment => assignment.LessonId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}