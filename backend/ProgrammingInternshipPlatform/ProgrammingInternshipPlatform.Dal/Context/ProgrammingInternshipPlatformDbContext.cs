using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Domain.Account.UserAccounts;
using ProgrammingInternshipPlatform.Domain.Backlog.Boards;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships;
using ProgrammingInternshipPlatform.Domain.Organisation.Centers;
using ProgrammingInternshipPlatform.Domain.ProjectHub.Projects;

namespace ProgrammingInternshipPlatform.Dal.Context;

public class ProgrammingInternshipPlatformDbContext : IdentityDbContext
{
    public ProgrammingInternshipPlatformDbContext() : base() {}

    public ProgrammingInternshipPlatformDbContext(DbContextOptions<ProgrammingInternshipPlatformDbContext> options) :
        base(options) {}
    
    public DbSet<Internship> Internships { get; set; }
    public DbSet<Center> Locations { get; set; }
    public DbSet<UserAccount> UserAccount { get; set; }
    public DbSet<Board> Boards { get; set; }
    public DbSet<Project> Projects { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(ProgrammingInternshipPlatformDbContext)));
    }
}