using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.Locations.Identifiers;
using ProgrammingInternshipPlatform.Domain.Locations.Models;

namespace ProgrammingInternshipPlatform.Dal.Configurations.LocationConfigs;

public class CompanyConfig : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasIndex(company => company.Id);
        builder.Property(company => company.Id)
            .HasConversion(id => id.Value,
                value => new CompanyId((value)));

        builder
            .HasMany(company => company.Locations)
            .WithOne()
            .HasForeignKey(location => location.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}