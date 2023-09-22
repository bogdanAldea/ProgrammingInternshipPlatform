using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipHub.VersionedCurriculums.Identifiers;
using ProgrammingInternshipPlatform.Domain.ModuleVersioning.VersionedModules.Identifier;

namespace ProgrammingInternshipPlatform.Dal.Configurations.VersionedModule;

public class VersionedModuleConfig : IEntityTypeConfiguration<Domain.ModuleVersioning.VersionedModules.Model.VersionedModule>
{
    public void Configure(EntityTypeBuilder<Domain.ModuleVersioning.VersionedModules.Model.VersionedModule> builder)
    {
        builder
            .HasKey(version => version.VersionedModuleId);

        builder
            .Property(version => version.VersionedCurriculumId)
            .HasConversion(id => id.Value, 
                value => new VersionedCurriculumId(value))
            .IsRequired();
        
        builder
            .Property(version => version.ChapterId)
            .HasConversion(id => id.Value, 
                value => new ChapterId(value))
            .IsRequired();
        
        builder
            .Property(version => version.VersionedModuleId)
            .HasConversion(id => id.Value, 
                value => new VersionedModuleId(value))
            .IsRequired();
    }
}