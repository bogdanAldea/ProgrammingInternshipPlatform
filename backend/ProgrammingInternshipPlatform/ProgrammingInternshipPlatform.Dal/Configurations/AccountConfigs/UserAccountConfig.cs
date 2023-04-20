using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.Account.Identifiers;
using ProgrammingInternshipPlatform.Domain.Account.Models;

namespace ProgrammingInternshipPlatform.Dal.Configurations.AccountConfigs;

public class UserAccountConfig : IEntityTypeConfiguration<UserAccount>
{
    public void Configure(EntityTypeBuilder<UserAccount> builder)
    {
        builder.HasKey(account => account.Id);
        builder.Property(account => account.Id)
            .HasConversion(id => id.Value, 
                value => new AccountId(value));
    }
}