using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.Backlog.Cards;
using ProgrammingInternshipPlatform.Domain.Backlog.Stages;
using ProgrammingInternshipPlatform.Domain.ProjectHub.WorkItems;

namespace ProgrammingInternshipPlatform.Dal.Configurations.Backlog;

public class CardConfig : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder.HasIndex(card => card.CardId);

        builder
            .Property(card => card.CardId)
            .HasConversion(
                id => id.Value,
                value => new CardId(value))
            .IsRequired();

        builder
            .Property(card => card.StageId)
            .HasConversion(
                id => id.Value,
                value => new StageId(value))
            .IsRequired();

        builder
            .Property(card => card.WorkItemId)
            .HasConversion(
                id => id.Value,
                value => new WorkItemId(value))
            .IsRequired();
    }
}