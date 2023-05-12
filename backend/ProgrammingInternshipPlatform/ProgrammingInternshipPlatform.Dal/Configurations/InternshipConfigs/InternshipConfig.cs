using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internship;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Timeframe;
using ProgrammingInternshipPlatform.Domain.Organization.Center;
using ProgrammingInternshipPlatform.Domain.Organization.Company;

namespace ProgrammingInternshipPlatform.Dal.Configurations.InternshipConfigs;

public class InternshipConfig : IEntityTypeConfiguration<Internship>
{
    public void Configure(EntityTypeBuilder<Internship> builder)
    {
        builder.HasKey(internship => internship.Id);
        
        builder
            .Property(internship => internship.Id)
            .HasConversion(
            id => id.Value, 
            value => new InternshipId(value))
            .IsRequired();
        
        builder
            .HasOne(internship => internship.Timeframe)
            .WithOne()
            .HasForeignKey<Timeframe>(timeframe => timeframe.InternshipId)
            .IsRequired();

        builder
            .HasOne<Location>()
            .WithOne()
            .HasForeignKey<Internship>(internship => internship.LocationId);

        builder
            .HasMany(internship => internship.Mentorships)
            .WithOne()
            .HasForeignKey(mentorship => mentorship.InternshipId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(internship => internship.CompanyId)
            .HasConversion(companyId => companyId.Value,
                value => new CompanyId(value));

        builder.Property(internship => internship.Status)
            .IsRequired();

        builder.Property(internship => internship.DurationInMonths)
            .IsRequired();

        builder.Property(internship => internship.MaximumInternsToEnroll)
            .IsRequired();
    }
}