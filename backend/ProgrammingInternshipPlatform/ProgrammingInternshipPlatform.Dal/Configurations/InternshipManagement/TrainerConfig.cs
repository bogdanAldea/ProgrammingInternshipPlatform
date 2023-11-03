using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.AccountManagement.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Trainers.Models;

namespace ProgrammingInternshipPlatform.Dal.Configurations.InternshipManagement;

public class TrainerConfig : IEntityTypeConfiguration<Trainer>
{
    public void Configure(EntityTypeBuilder<Trainer> builder)
    {
        builder
            .ToTable(AggregatesToTableNames.InternshipManagement.Trainers);

        builder
            .HasKey(trainer => trainer.TrainerId);

        builder
            .Property(trainer => trainer.TrainerId)
            .HasConversion(id => id.Value, 
                value => new TrainerId(value))
            .IsRequired();
        
        builder
            .Property(trainer => trainer.AccountId)
            .HasConversion(id => id.Value, 
                value => new AccountId(value))
            .IsRequired();
    }
}