using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Interns;
using ProgrammingInternshipPlatform.Domain.ProjectHub.Boards;
using ProgrammingInternshipPlatform.Domain.ProjectHub.Projects;
using ProgrammingInternshipPlatform.Domain.ProjectHub.Stages;

namespace ProgrammingInternshipPlatform.Dal.Configurations.ProjectHub;

public class BoardConfig : IEntityTypeConfiguration<Board>
{
    public void Configure(EntityTypeBuilder<Board> builder)
    {
        builder.HasIndex(board => board.BoardId);

        builder
            .Property(board => board.BoardId)
            .HasConversion(
                id => id.Value,
                value => new BoardId(value))
            .IsRequired();
        
        builder
            .Property(board => board.ProjectId)
            .HasConversion(
                id => id.Value,
                value => new ProjectId(value))
            .IsRequired();
        
        builder
            .Property(board => board.OwnerIntern)
            .HasConversion(
                id => id.Value,
                value => new InternId(value))
            .IsRequired();

        builder
            .HasMany(project => project.Stages)
            .WithOne()
            .HasForeignKey(stage => stage.BoardId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}