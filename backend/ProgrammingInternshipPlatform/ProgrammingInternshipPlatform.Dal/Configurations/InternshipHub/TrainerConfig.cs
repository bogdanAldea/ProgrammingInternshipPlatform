using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Trainers.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Trainers.Models;

namespace ProgrammingInternshipPlatform.Dal.Configurations.InternshipHub;

public class TrainerConfig : IEntityTypeConfiguration<Trainer>
{
    public void Configure(EntityTypeBuilder<Trainer> builder)
    {
        builder
            .HasKey(trainer => trainer.Id);

        builder
            .Property(trainer => trainer.Id)
            .HasConversion(id => id.Value,
                value => new TrainerId(value))
            .IsRequired();
        
    }
}