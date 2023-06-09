using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Timeframes;
using ProgrammingInternshipPlatform.Domain.Organization.Companys;

namespace ProgrammingInternshipPlatform.Dal.Configurations.InternshipManagement;

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
            .HasOne<Domain.Organization.Center.Location>()
            .WithOne()
            .HasForeignKey<Internship>(internship => internship.LocationId);

        builder
            .HasMany(internship => internship.Mentorships)
            .WithOne()
            .HasForeignKey(mentorship => mentorship.InternshipId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(internship => internship.Interns)
            .WithOne()
            .HasForeignKey(intern => intern.InternshipId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(internship => internship.Trainers)
            .WithMany(trainer => trainer.Internships);

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