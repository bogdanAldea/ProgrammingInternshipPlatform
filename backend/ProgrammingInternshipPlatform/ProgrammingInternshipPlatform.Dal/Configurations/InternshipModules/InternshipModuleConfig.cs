using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.Curriculum.Modules;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships;
using ProgrammingInternshipPlatform.Domain.InternshipModule;

namespace ProgrammingInternshipPlatform.Dal.Configurations.InternshipModules;

public class InternshipModuleConfig : IEntityTypeConfiguration<InternshipModule>
{
    public void Configure(EntityTypeBuilder<Domain.InternshipModule.InternshipModule> builder)
    {
        builder.HasKey(iModule => iModule.InternshipModuleId);

        builder.Property(iModule => iModule.InternshipModuleId)
            .HasConversion(id => id.Value,
                value => new InternshipModuleId(value));
        
        builder.Property(iModule => iModule.InternshipId)
            .HasConversion(id => id.Value,
                value => new InternshipId(value));
        
        builder.Property(iModule => iModule.ModuleId)
            .HasConversion(id => id.Value,
                value => new ModuleId(value));
    }
}