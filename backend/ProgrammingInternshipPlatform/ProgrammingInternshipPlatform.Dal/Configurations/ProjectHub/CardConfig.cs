using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.ProjectHub.Cards;
using ProgrammingInternshipPlatform.Domain.ProjectHub.Cards.Labels;
using ProgrammingInternshipPlatform.Domain.ProjectHub.Stages;

namespace ProgrammingInternshipPlatform.Dal.Configurations.ProjectHub;

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
            .Property(card => card.Title)
            .IsRequired();

        builder
            .HasIndex(card => card.Title)
            .IsUnique();
        
        builder
            .Property(card => card.Description)
            .IsRequired();

        builder
            .HasIndex(card => card.Description)
            .IsUnique();

        builder
            .Property(card => card.AddedOn)
            .HasDefaultValue(DateTime.Today)
            .IsRequired();

        builder
            .Property(card => card.TypeLabel)
            .HasConversion(
                label => (int)label,
                value => (TypeLabel)value)
            .IsRequired();
        
        builder
            .Property(card => card.PriorityLabel)
            .HasConversion(
                label => (int)label,
                value => (PriorityLabel)value)
            .IsRequired();
        
        builder
            .Property(card => card.ComplexityLabel)
            .HasConversion(
                label => (int)label,
                value => (ComplexityLabel)value)
            .IsRequired();

        builder
            .Property(card => card.RiskLabel)
            .HasConversion(
                label => label.HasValue ? (int)label.Value : default(int?),
                value => value.HasValue ? (RiskLabel)value.Value : default);
    }
}