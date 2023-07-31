using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Interns.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Mentorships.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Mentorships.Models;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Trainers.Identifiers;

namespace ProgrammingInternshipPlatform.Dal.Configurations.InternshipHub;

public class MentorshipConfig : IEntityTypeConfiguration<Mentorship>
{
    public void Configure(EntityTypeBuilder<Mentorship> builder)
    {
        builder
            .HasKey(mentorship => mentorship.Id);

        builder
            .Property(mentorship => mentorship.Id)
            .HasConversion(id => id.Value,
                value => new MentorshipId(value))
            .IsRequired();
        
        builder
            .Property(mentorship => mentorship.TrainerId)
            .HasConversion(id => id.Value,
                value => new TrainerId(value))
            .IsRequired();
        
        builder
            .Property(mentorship => mentorship.InternId)
            .HasConversion(id => id.Value,
                value => new InternId(value))
            .IsRequired();
        
        builder
            .Property(mentorship => mentorship.InternshipId)
            .HasConversion(id => id.Value,
                value => new InternshipId(value))
            .IsRequired();
    }
}