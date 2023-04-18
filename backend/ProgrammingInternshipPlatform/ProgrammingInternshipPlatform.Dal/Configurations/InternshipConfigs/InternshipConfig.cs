using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.Internships.Identifiers;
using ProgrammingInternshipPlatform.Domain.Internships.Models;

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

        builder.Property(internship => internship.Status)
            .IsRequired();

        builder.Property(internship => internship.DurationInMonths)
            .IsRequired();

        builder.Property(internship => internship.MaximumInternsToEnroll)
            .IsRequired();
    }
}