using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.AccountManagement.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Interns.Models;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships.Models;

namespace ProgrammingInternshipPlatform.Dal.Configurations.InternshipManagement;

public class InternConfig : IEntityTypeConfiguration<Intern>
{
    public void Configure(EntityTypeBuilder<Intern> builder)
    {
        builder
            .ToTable(AggregatesToTableNames.InternshipManagement.Interns);

        builder
            .HasKey(intern => intern.InternId);

        builder
            .Property(intern => intern.InternId)
            .HasConversion(id => id.Value, 
                value => new InternId(value))
            .IsRequired();
        
        builder
            .Property(intern => intern.AccountId)
            .HasConversion(id => id.Value, 
                value => new AccountId(value))
            .IsRequired();
        
        builder
            .Property(intern => intern.InternshipId)
            .HasConversion(id => id.Value, 
                value => new InternshipId(value))
            .IsRequired();
    }
}