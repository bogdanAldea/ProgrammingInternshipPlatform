using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Interns;
using ProgrammingInternshipPlatform.Domain.ProjectHub.Boards;
using ProgrammingInternshipPlatform.Domain.ProjectHub.Projects;

namespace ProgrammingInternshipPlatform.Dal.Configurations.ProjectHub;

public class ProjectConfig : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(project => project.ProjectId);

        builder
            .Property(project => project.ProjectId)
            .HasConversion(
                id => id.Value, 
                value => new ProjectId(value))
            .IsRequired();

        builder
            .Property(project => project.InternId)
            .HasConversion(
                id => id.Value,
                value => new InternId(value))
            .IsRequired();

        builder
            .Property(project => project.ProjectStatus)
            .IsRequired();

        builder
            .HasOne(project => project.Board)
            .WithOne()
            .HasForeignKey<Board>(board => board.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Property(project => project.Title)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(project => project.Documentation)
            .IsRequired();
    }
}