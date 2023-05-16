using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Domain.Account.UserAccount;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internship;
using ProgrammingInternshipPlatform.Domain.Organization.Center;

namespace ProgrammingInternshipPlatform.Dal.Context;

public class ProgrammingInternshipPlatformDbContext : IdentityDbContext
{
    public ProgrammingInternshipPlatformDbContext() : base() {}

    public ProgrammingInternshipPlatformDbContext(DbContextOptions<ProgrammingInternshipPlatformDbContext> options) :
        base(options) {}
    
    public DbSet<Internship> Internships { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<UserAccount> UserAccount { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(ProgrammingInternshipPlatformDbContext)));
    }
}