using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.LearningResources.Models;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Lessons.Models;

namespace ProgrammingInternshipPlatform.Dal.Configurations.GeneralCurriculum;

public class LearningResourceConfig : IEntityTypeConfiguration<LearningResource>
{
    public void Configure(EntityTypeBuilder<LearningResource> builder)
    {
        builder
            .ToTable(AggregatesToTableNames.CurriculumManagement.LearningResources);
        
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
            .Property(resource => resource.ResourceType)
            .IsRequired();

        builder
            .Property(resource => resource.Url)
            .IsRequired();
    }
}