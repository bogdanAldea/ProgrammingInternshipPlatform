using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.AccountManagement.Identifiers;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Topics.Models;
using ProgrammingInternshipPlatform.Domain.ModuleManagement.Models;

namespace ProgrammingInternshipPlatform.Dal.Configurations.ModuleManagement;

public class ModuleConfig : IEntityTypeConfiguration<Module>
{
    public void Configure(EntityTypeBuilder<Module> builder)
    {
        builder
            .HasKey(module => module.ModuleId);

        builder
            .Property(module => module.ModuleId)
            .HasConversion(id => id.Value,
                value => new ModuleId(value))
            .IsRequired();
        
        builder
            .Property(module => module.TopicId)
            .HasConversion(id => id.Value,
                value => new TopicId(value))
            .IsRequired();
        
        builder
            .Property(module => module.VersionedByUser)
            .HasConversion(id => id.Value,
                value => new AccountId(value))
            .IsRequired();

        builder
            .Property(module => module.VersionedOnDate)
            .IsRequired();
        
        builder
            .Property(module => module.VersionNumber)
            .IsRequired();

        builder
            .HasIndex(module => module.VersionNumber)
            .IsUnique();
    }
}