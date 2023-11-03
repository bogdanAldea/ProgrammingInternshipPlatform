using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Interns.Models;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Mentorships.Models;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Trainers.Models;

namespace ProgrammingInternshipPlatform.Dal.Configurations.InternshipManagement;

public class MentorshipConfig : IEntityTypeConfiguration<Mentorship>
{
    public void Configure(EntityTypeBuilder<Mentorship> builder)
    {
        builder
            .ToTable(AggregatesToTableNames.InternshipManagement.Mentorships);

        builder
            .HasKey(mentorship => mentorship.MentorshipId);

        builder
            .Property(mentorship => mentorship.MentorshipId)
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
    }
}