using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.Curriculum.Assignments;
using ProgrammingInternshipPlatform.Domain.Curriculum.Lessons;
using ProgrammingInternshipPlatform.Domain.Curriculum.Modules;

namespace ProgrammingInternshipPlatform.Dal.Configurations.Curriculum;

public class LessonConfig : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.HasKey(lesson => lesson.LessonId);

        builder
            .Property(lesson => lesson.LessonId)
            .HasConversion(
                id => id.Value,
                value => new LessonId(value))
            .IsRequired();
        
        builder
            .Property(lesson => lesson.ModuleId)
            .HasConversion(
                id => id.Value,
                value => new ModuleId(value))
            .IsRequired();

        builder
            .HasIndex(lesson => lesson.Title)
            .IsUnique();

        builder
            .Property(lesson => lesson.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .HasIndex(lesson => lesson.Description)
            .IsUnique();

        builder
            .Property(lesson => lesson.Description)
            .IsRequired()
            .HasMaxLength(560);

        builder
            .HasOne(lesson => lesson.Assignment)
            .WithOne()
            .HasForeignKey<Assignment>(assignment => assignment.LessonId)
            .IsRequired();
    }
}