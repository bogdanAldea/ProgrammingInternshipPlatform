using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.AccountManagement.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipManagement;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships.Models;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Trainers.Models;

namespace ProgrammingInternshipPlatform.Dal.Configurations.InternshipManagement;

public class InternshipConfig : IEntityTypeConfiguration<Internship>
{
    public void Configure(EntityTypeBuilder<Internship> builder)
    {
        builder
            .ToTable(AggregatesToTableNames.InternshipManagement.Internships);
        
        builder
            .HasKey(internship => internship.InternshipId);

        builder
            .Property(internship => internship.InternshipId)
            .HasConversion(id => id.Value,
                value => new InternshipId(value))
            .IsRequired();

        builder
            .Property(internship => internship.CoordinatorId)
            .HasConversion(id => id.Value, 
                value => new AccountId(value))
            .IsRequired();

        builder
            .Property(internship => internship.ScheduledStartDate)
            .IsRequired();

        builder
            .Property(internship => internship.DurationInMonths)
            .IsRequired();
        
        builder
            .Property(internship => internship.MaxInternsToEnroll)
            .IsRequired();
        
        builder
            .Property(internship => internship.InternshipStatus)
            .IsRequired();

        builder
            .HasMany(internship => internship.Interns)
            .WithOne()
            .HasForeignKey(intern => intern.InternshipId);
        
        builder
            .HasMany(internship => internship.Mentorships)
            .WithOne()
            .HasForeignKey(mentorship => mentorship.InternshipId);

        builder
            .HasMany(internship => internship.Trainers)
            .WithMany(trainer => trainer.Internships)
            .UsingEntity<AssignedTrainer>(
                assigned => assigned
                    .HasOne<Trainer>()
                    .WithMany()
                    .HasForeignKey(assignedTrainer => assignedTrainer.TrainerId),
                assigned => assigned
                    .HasOne<Internship>()
                    .WithMany()
                    .HasForeignKey(assignedTrainer => assignedTrainer.InternshipId),
                assigned =>
                {
                    assigned.HasKey(assignedTrainer => new { assignedTrainer.TrainerId, assignedTrainer.InternshipId });
                    
                    assigned.ToTable(AggregatesToTableNames.InternshipManagement.AssignedTrainers);
                    
                    assigned.Property(a => a.InternshipId)
                        .HasConversion(id => id.Value, 
                            value => new InternshipId(value))
                        .IsRequired();
                    
                    assigned.Property(a => a.TrainerId)
                        .HasConversion(id => id.Value, 
                            value => new TrainerId(value))
                        .IsRequired();
                });
    }
}