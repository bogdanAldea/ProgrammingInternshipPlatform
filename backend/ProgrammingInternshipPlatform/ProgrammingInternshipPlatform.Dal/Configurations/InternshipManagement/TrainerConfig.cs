using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.Account.UserAccounts;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Trainers;

namespace ProgrammingInternshipPlatform.Dal.Configurations.InternshipManagement;

public class TrainerConfig : IEntityTypeConfiguration<Trainer>
{
    public void Configure(EntityTypeBuilder<Trainer> builder)
    {
        builder.HasKey(trainer => trainer.Id);
        
        builder.Property(trainer => trainer.Id)
            .HasConversion(id => id.Value, 
                value => new TrainerId(value));

        builder.Property(trainer => trainer.AccountId)
            .HasConversion(id => id.Value,
                value => new AccountId(value));
    }
}