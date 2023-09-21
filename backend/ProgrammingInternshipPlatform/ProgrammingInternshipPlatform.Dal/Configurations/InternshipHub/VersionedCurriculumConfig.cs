using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipHub.VersionedCurriculums.Identifiers;

namespace ProgrammingInternshipPlatform.Dal.Configurations.InternshipHub;

public class VersionedCurriculumConfig : IEntityTypeConfiguration<Domain.InternshipHub.VersionedCurriculums.Modules.VersionedCurriculum>
{
    public void Configure(EntityTypeBuilder<Domain.InternshipHub.VersionedCurriculums.Modules.VersionedCurriculum> builder)
    {
        builder
            .HasKey(version => version.VersionedCurriculumId);

        builder
            .Property(version => version.VersionedCurriculumId)
            .HasConversion(id => id.Value,
                value => new VersionedCurriculumId(value))
            .IsRequired();
    }
}