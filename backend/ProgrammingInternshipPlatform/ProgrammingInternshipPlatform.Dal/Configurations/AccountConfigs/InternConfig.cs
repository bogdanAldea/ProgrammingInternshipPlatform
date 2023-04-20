using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.Account.Identifiers;
using ProgrammingInternshipPlatform.Domain.Account.Models;

namespace ProgrammingInternshipPlatform.Dal.Configurations.AccountConfigs;

public class InternConfig : IEntityTypeConfiguration<Intern>
{
    public void Configure(EntityTypeBuilder<Intern> builder)
    {
        builder.HasKey(trainer => trainer.Id);
        
        builder.Property(trainer => trainer.Id)
            .HasConversion(id => id.Value, 
                value => new InternId(value));
        
        builder
            .HasOne(intern => intern.Account)
            .WithOne()
            .HasForeignKey<Intern>(intern => intern.AccountId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}