using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.Account.Intern;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internship;

namespace ProgrammingInternshipPlatform.Dal.Configurations.AccountConfigs;

public class InternConfig : IEntityTypeConfiguration<Intern>
{
    public void Configure(EntityTypeBuilder<Intern> builder)
    {
        builder.HasKey(intern => intern.Id);
        
        builder.Property(intern => intern.Id)
            .HasConversion(id => id.Value, 
                value => new InternId(value));
        
        builder
            .HasOne(intern => intern.Account)
            .WithOne()
            .HasForeignKey<Intern>(intern => intern.AccountId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(intern => intern.InternshipId)
            .HasConversion(id => id.Value, 
                value => new InternshipId(value));
    }
}