using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.Organization.Center;

namespace ProgrammingInternshipPlatform.Dal.Configurations.Location;

public class LocationConfig : IEntityTypeConfiguration<Domain.Organization.Center.Location>
{
    public void Configure(EntityTypeBuilder<Domain.Organization.Center.Location> builder)
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
    }
}