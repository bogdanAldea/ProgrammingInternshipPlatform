using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.Account.UserAccount;
using ProgrammingInternshipPlatform.Domain.Organization.Company;

namespace ProgrammingInternshipPlatform.Dal.Configurations.AccountConfigs;

public class UserAccountConfig : IEntityTypeConfiguration<UserAccount>
{
    public void Configure(EntityTypeBuilder<UserAccount> builder)
    {
        builder.HasKey(account => account.Id);
        builder.Property(account => account.Id)
            .HasConversion(id => id.Value, 
                value => new AccountId(value));
        
        builder.Property(userAccount => userAccount.CompanyId)
            .HasConversion(id => id.Value, 
                value => new CompanyId(value));
    }
}