using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Lesson.Identifier;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.LearningResources.Identifiers;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.LearningResources.Models;

namespace ProgrammingInternshipPlatform.Dal.Configurations.GeneralCurriculum;

public class LearningResourceConfig : IEntityTypeConfiguration<LearningResource>
{
    public void Configure(EntityTypeBuilder<LearningResource> builder)
    {
        builder
            .HasKey(resource => resource.LearningResourceId);

        builder
            .Property(resource => resource.LearningResourceId)
            .HasConversion(id => id.Value,
                value => new LearningResourceId(value))
            .IsRequired();
        
        builder
            .Property(resource => resource.LessonId)
            .HasConversion(id => id.Value,
                value => new LessonId(value))
            .IsRequired();

        builder
            .Property(resource => resource.Url)
            .IsRequired();

        builder
            .Property(resource => resource.LearningResourceType)
            .IsRequired();
    }
}