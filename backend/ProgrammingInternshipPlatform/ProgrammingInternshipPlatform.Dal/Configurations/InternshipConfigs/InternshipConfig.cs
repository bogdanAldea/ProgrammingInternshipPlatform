using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Models;
using ProgrammingInternshipPlatform.Domain.Locations.Models;

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

        builder.Property(internship => internship.Status)
            .IsRequired();

        builder.Property(internship => internship.DurationInMonths)
            .IsRequired();

        builder.Property(internship => internship.MaximumInternsToEnroll)
            .IsRequired();
    }
}