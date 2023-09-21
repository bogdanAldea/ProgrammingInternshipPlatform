using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Identifiers;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Models;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.ValidationConstants;

namespace ProgrammingInternshipPlatform.Dal.Configurations.GeneralCurriculum;

public class ChapterConfig : IEntityTypeConfiguration<Chapter>
{
    public void Configure(EntityTypeBuilder<Chapter> builder)
    {
        builder
            .HasKey(chapter => chapter.ChapterId);

        builder
            .Property(chapter => chapter.ChapterId)
            .HasConversion(id => id.Value, 
                value => new ChapterId(value))
            .IsRequired();
        
        builder
            .Property(chapter => chapter.Title)
            .HasMaxLength(ChapterValidationConstants.ChapterTitleLenght)
            .IsRequired();

        builder
            .Property(chapter => chapter.Description)
            .HasMaxLength(ChapterValidationConstants.ChapterDescriptionLenght)
            .IsRequired();

        builder
            .HasMany(chapter => chapter.Lessons)
            .WithOne()
            .HasForeignKey(lesson => lesson.ChapterId);
    }
}