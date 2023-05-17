using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.Account.Trainer;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internship;

namespace ProgrammingInternshipPlatform.Dal.Configurations.AccountConfigs;

public class TrainerConfig : IEntityTypeConfiguration<Trainer>
{
    public void Configure(EntityTypeBuilder<Trainer> builder)
    {
        builder.HasKey(trainer => trainer.Id);
        
        builder.Property(trainer => trainer.Id)
            .HasConversion(id => id.Value, 
                value => new TrainerId(value));

        builder
            .HasOne(trainer => trainer.Account)
            .WithOne()
            .HasForeignKey<Trainer>(trainer => trainer.AccountId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}