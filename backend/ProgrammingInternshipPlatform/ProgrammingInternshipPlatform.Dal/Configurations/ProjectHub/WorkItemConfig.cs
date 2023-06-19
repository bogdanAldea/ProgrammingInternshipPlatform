using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.ProjectHub.Projects;
using ProgrammingInternshipPlatform.Domain.ProjectHub.WorkItems;

namespace ProgrammingInternshipPlatform.Dal.Configurations.ProjectHub;

public class WorkItemConfig : IEntityTypeConfiguration<WorkItem>
{
    public void Configure(EntityTypeBuilder<WorkItem> builder)
    {
        builder.HasKey(workItem => workItem.WorkItemId);

        builder
            .Property(workItem => workItem.WorkItemId)
            .HasConversion(
                id => id.Value,
                value => new WorkItemId(value))
            .IsRequired();
        
        builder
            .Property(workItem => workItem.ProjectId)
            .HasConversion(
                id => id.Value,
                value => new ProjectId(value))
            .IsRequired();
    }
}