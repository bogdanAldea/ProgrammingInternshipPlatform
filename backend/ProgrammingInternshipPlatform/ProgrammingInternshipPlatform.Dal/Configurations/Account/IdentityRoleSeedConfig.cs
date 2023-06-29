using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProgrammingInternshipPlatform.Dal.Configurations.Account;

public class IdentityRoleSeedConfig : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.ToTable("AspNetRoles");
        builder.HasData(
            new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Administrator", NormalizedName = "ADMINISTRATOR" },
            new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Coordinator", NormalizedName = "COORDINATOR" },
            new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Trainer", NormalizedName = "TRAINER" },
            new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Intern", NormalizedName = "INTERN" },
            new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "HR Rep", NormalizedName = "HR REP" },
            new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Development", NormalizedName = "DEVELOPMENT" }
        );
    }
}