using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Models;

namespace ProgrammingInternshipPlatform.Dal.Configurations.InternshipHub;

public class InternshipConfig : IEntityTypeConfiguration<Internship>
{
    public void Configure(EntityTypeBuilder<Internship> builder)
    {
        builder
            .HasKey(internship => internship.Id);

        builder
            .Property(internship => internship.Id)
            .HasConversion(id => id.Value,
                value => new InternshipId(value))
            .IsRequired();

        builder
            .Property(internship => internship.Status)
            .IsRequired();

        builder
            .Property(internship => internship.ScheduledToStartOn)
            .IsRequired();
        
        builder
            .Property(internship => internship.EstimatedToEndOn)
            .IsRequired();
        
        builder
            .Property(internship => internship.DurationInMonths)
            .IsRequired();
        
        builder
            .Property(internship => internship.MaxInternsToEnroll)
            .IsRequired();

        builder
            .HasMany(internship => internship.Trainers)
            .WithMany(trainer => trainer.Internships);

        builder
            .HasMany(internship => internship.Interns)
            .WithOne()
            .HasForeignKey(intern => intern.InternshipId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .HasMany(internship => internship.Mentorships)
            .WithOne()
            .HasForeignKey(mentorship => mentorship.InternshipId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}