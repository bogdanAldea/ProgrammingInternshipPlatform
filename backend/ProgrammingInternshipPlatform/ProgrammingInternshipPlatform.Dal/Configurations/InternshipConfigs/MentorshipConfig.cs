using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.Account.Intern;
using ProgrammingInternshipPlatform.Domain.Account.Trainer;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internship;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Mentorship;

namespace ProgrammingInternshipPlatform.Dal.Configurations.InternshipConfigs;

public class MentorshipConfig : IEntityTypeConfiguration<Mentorship>
{
    public void Configure(EntityTypeBuilder<Mentorship> builder)
    {
        builder.HasKey(mentorship => mentorship.Id);
        builder.Property(mentorship => mentorship.Id).IsRequired();
        builder.Property(mentorship => mentorship.Id)
            .HasConversion(id => id.Value, 
                value => new MentorshipId(value));
        
        builder.Property(mentorship => mentorship.TrainerId).IsRequired();
        builder.Property(mentorship => mentorship.TrainerId)
            .HasConversion(id => id.Value, 
                value => new TrainerId(value));
        
        builder.Property(mentorship => mentorship.InternId).IsRequired();
        builder.Property(mentorship => mentorship.InternId)
            .HasConversion(id => id.Value, 
                value => new InternId(value));
        
        builder.Property(mentorship => mentorship.InternshipId).IsRequired();
        builder.Property(mentorship => mentorship.InternshipId)
            .HasConversion(id => id.Value, 
                value => new InternshipId(value));
    }
}