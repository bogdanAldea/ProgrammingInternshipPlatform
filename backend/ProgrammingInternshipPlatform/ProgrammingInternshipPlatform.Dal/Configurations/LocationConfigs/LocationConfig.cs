using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.Locations.Identifiers;
using ProgrammingInternshipPlatform.Domain.Locations.Models;

namespace ProgrammingInternshipPlatform.Dal.Configurations.LocationConfigs;

public class LocationConfig : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasKey(location => location.Id);
        
        builder.Property(location => location.Id)
            .HasConversion(id => id.Value, 
                value => new LocationId(value));

        builder.Property(location => location.Center)
            .IsRequired();

        builder.HasIndex(location => location.Center)
            .IsUnique();

        builder.Property(location => location.Country)
            .IsRequired();

        builder.HasIndex(location => location.Country)
            .IsUnique();
    }
}