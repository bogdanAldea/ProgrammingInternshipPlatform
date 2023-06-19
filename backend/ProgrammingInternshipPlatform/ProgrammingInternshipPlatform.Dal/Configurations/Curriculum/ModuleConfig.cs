using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.Curriculum.Modules;

namespace ProgrammingInternshipPlatform.Dal.Configurations.Curriculum;

public class ModuleConfig : IEntityTypeConfiguration<Module>
{
    public void Configure(EntityTypeBuilder<Module> builder)
    {
        builder.HasKey(module => module.ModuleId);

        builder
            .Property(module => module.ModuleId)
            .HasConversion(
                id => id.Value,
                value => new ModuleId(value))
            .IsRequired();

        builder
            .HasIndex(module => module.Title)
            .IsUnique();

        builder
            .Property(module => module.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .HasIndex(module => module.Description)
            .IsUnique();

        builder
            .Property(module => module.Description)
            .IsRequired()
            .HasMaxLength(560);

        builder
            .HasMany(module => module.Lessons)
            .WithOne()
            .HasForeignKey(lesson => lesson.ModuleId)
            .IsRequired();
    }
}