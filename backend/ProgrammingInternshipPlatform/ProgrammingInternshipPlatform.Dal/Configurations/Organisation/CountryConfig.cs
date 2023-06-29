using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.Organisation.Companies;
using ProgrammingInternshipPlatform.Domain.Organisation.Countries;

namespace ProgrammingInternshipPlatform.Dal.Configurations.Organisation;

public class CountryConfig : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(country => country.CountryId);
        
        builder.Property(country => country.CountryId)
            .HasConversion(id => id.Value, 
                value => new CountryId(value));
        
        builder.Property(country => country.CompanyId)
            .HasConversion(id => id.Value, 
                value => new CompanyId(value));

        builder.HasMany(country => country.Centers)
            .WithOne()
            .HasForeignKey(center => center.CountryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}