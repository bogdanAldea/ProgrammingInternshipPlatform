using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.Organisation.Company;

namespace ProgrammingInternshipPlatform.Dal.Configurations.Organisation;

public class CompanyConfig : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(company => company.Id);
        builder.Property(company => company.Id)
            .HasConversion(id => id.Value,
                value => new CompanyId((value)));

        builder
            .HasMany(company => company.Countries)
            .WithOne()
            .HasForeignKey(country => country.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}