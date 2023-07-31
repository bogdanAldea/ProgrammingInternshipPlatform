using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Interns.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Interns.Models;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Identifiers;

namespace ProgrammingInternshipPlatform.Dal.Configurations.InternshipHub;

public class InternConfig : IEntityTypeConfiguration<Intern>
{
    public void Configure(EntityTypeBuilder<Intern> builder)
    {
        builder
            .HasKey(intern => intern.InternId);

        builder
            .Property(intern => intern.InternId)
            .HasConversion(id => id.Value, 
                value => new InternId(value))
            .IsRequired();

        builder
            .Property(intern => intern.InternshipId)
            .HasConversion(id => id.Value,
                value => new InternshipId(value));
    }
}