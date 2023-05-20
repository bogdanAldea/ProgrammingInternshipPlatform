using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.Backlog.Boards;
using ProgrammingInternshipPlatform.Domain.Backlog.Stages;

namespace ProgrammingInternshipPlatform.Dal.Configurations.Backlog;

public class StageConfig : IEntityTypeConfiguration<Stage>
{
    public void Configure(EntityTypeBuilder<Stage> builder)
    {
        builder.HasIndex(stage => stage.StageId);

        builder
            .Property(stage => stage.StageId)
            .HasConversion(
                id => id.Value,
                value => new StageId(value))
            .IsRequired();

        builder
            .Property(stage => stage.BoardId)
            .HasConversion(
                id => id.Value,
                value => new BoardId(value))
            .IsRequired();

        builder
            .HasIndex(stage => stage.Title)
            .IsUnique();

        builder
            .Property(stage => stage.Title)
            .HasMaxLength(50);
        
        builder
            .HasIndex(stage => new { stage.BoardId, stage.Order })
            .IsUnique();

        builder
            .Property(stage => stage.Order)
            .IsRequired();

        builder
            .HasMany(stage => stage.Cards)
            .WithOne()
            .HasForeignKey(card => card.StageId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}