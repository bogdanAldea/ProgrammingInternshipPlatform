using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.Account.UserAccounts;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Interns;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships;

namespace ProgrammingInternshipPlatform.Dal.Configurations.InternshipManagement;

public class InternConfig : IEntityTypeConfiguration<Intern>
{
    public void Configure(EntityTypeBuilder<Intern> builder)
    {
        builder.HasKey(intern => intern.Id);
        
        builder.Property(intern => intern.Id)
            .HasConversion(id => id.Value, 
                value => new InternId(value));

        builder.Property(intern => intern.InternshipId)
            .HasConversion(id => id.Value, 
                value => new InternshipId(value));

        builder.Property(intern => intern.AccountId)
            .HasConversion(id => id.Value,
                value => new AccountId(value));
    }
}