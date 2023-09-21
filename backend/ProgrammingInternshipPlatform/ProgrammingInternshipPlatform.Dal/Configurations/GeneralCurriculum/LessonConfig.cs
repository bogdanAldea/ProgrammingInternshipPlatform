using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Assignment.Model;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Identifiers;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Lesson.Identifier;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Lesson.Model;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.ValidationConstants;

namespace ProgrammingInternshipPlatform.Dal.Configurations.GeneralCurriculum;

public class LessonConfig : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder
            .HasKey(lesson => lesson.LessonId);

        builder
            .Property(lesson => lesson.LessonId)
            .HasConversion(id => id.Value,
                value => new LessonId(value))
            .IsRequired();
        
        builder
            .Property(lesson => lesson.ChapterId)
            .HasConversion(id => id.Value,
                value => new ChapterId(value))
            .IsRequired();

        builder
            .Property(lesson => lesson.Title)
            .HasMaxLength(ChapterValidationConstants.LessonTitleLength)
            .IsRequired();
        
        builder
            .Property(lesson => lesson.Description)
            .HasMaxLength(ChapterValidationConstants.LessonDescriptionLength)
            .IsRequired();

        builder
            .HasOne(lesson => lesson.Assignment)
            .WithOne()
            .HasForeignKey<Assignment>(assignment => assignment.LessonId);
    }
}