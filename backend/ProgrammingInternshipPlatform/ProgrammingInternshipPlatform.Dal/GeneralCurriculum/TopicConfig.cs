using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.Topics.Identifiers;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.Topics.Models;
using ProgrammingInternshipPlatform.Domain.Shared.Validators;

namespace ProgrammingInternshipPlatform.Dal.GeneralCurriculum;

public class TopicConfig : IEntityTypeConfiguration<Topic>
{
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
        builder
            .HasKey(topic => topic.TopicId);
        
        builder
            .Property(topic => topic.TopicId)
            .HasConversion(id => id.Value, 
                value => new TopicId(value))
            .IsRequired();
        
        builder
            .Property(topic => topic.Title)
            .HasMaxLength(RuleConstants.GeneralCurriculum.TopicTitleMaxLength)
            .IsRequired();
        
        builder
            .Property(lesson => lesson.Description)
            .HasMaxLength(RuleConstants.GeneralCurriculum.TopicDescriptionMaxLength)
            .IsRequired();

        builder
            .HasMany(topic => topic.Lessons)
            .WithOne()
            .HasForeignKey(lesson => lesson.TopicId)
            .IsRequired();

        builder
            .Property(topic => topic.SyllabusOrder)
            .IsRequired();

        builder
            .Property(topic => topic.TopicType)
            .IsRequired();
        
        builder
            .Property(topic => topic.VersioningState)
            .IsRequired();
    }
}