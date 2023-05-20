using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.ProjectHub.AcceptanceCriteria;
using ProgrammingInternshipPlatform.Domain.ProjectHub.WorkItems;

namespace ProgrammingInternshipPlatform.Dal.Configurations.ProjectHub;

public class AcceptanceCriterionConfig : IEntityTypeConfiguration<AcceptanceCriterion>
{
    public void Configure(EntityTypeBuilder<AcceptanceCriterion> builder)
    {
        builder.HasIndex(criterion => criterion.AcceptanceCriterionId);

        builder
            .Property(criterion => criterion.AcceptanceCriterionId)
            .HasConversion(
                id => id.Value,
                value => new AcceptanceCriterionId(value))
            .IsRequired();
        
        builder
            .Property(criterion => criterion.WorkItemId)
            .HasConversion(
                id => id.Value,
                value => new WorkItemId(value))
            .IsRequired();
    }
}