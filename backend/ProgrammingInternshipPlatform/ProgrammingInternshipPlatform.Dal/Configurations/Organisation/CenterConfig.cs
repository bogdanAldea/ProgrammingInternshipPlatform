using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.Organisation.Centers;
using ProgrammingInternshipPlatform.Domain.Organisation.Countries;

namespace ProgrammingInternshipPlatform.Dal.Configurations.Organisation;

public class CenterConfig : IEntityTypeConfiguration<Center>
{
    public void Configure(EntityTypeBuilder<Center> builder)
    {
        builder.HasKey(center => center.Id);
        
        builder.Property(center => center.Id)
            .HasConversion(id => id.Value, 
                value => new CenterId(value));
        
        builder.Property(center => center.CountryId)
            .HasConversion(id => id.Value, 
                value => new CountryId(value));
    }
}