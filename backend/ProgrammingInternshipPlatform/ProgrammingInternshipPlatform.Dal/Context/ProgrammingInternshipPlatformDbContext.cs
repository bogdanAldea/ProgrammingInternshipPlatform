using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Domain.Internships.Models;
using ProgrammingInternshipPlatform.Domain.Locations.Models;

namespace ProgrammingInternshipPlatform.Dal.Context;

public class ProgrammingInternshipPlatformDbContext : DbContext
{
    public ProgrammingInternshipPlatformDbContext() : base() {}

    public ProgrammingInternshipPlatformDbContext(DbContextOptions<ProgrammingInternshipPlatformDbContext> options) :
        base(options) {}
    
    public DbSet<Internship> Internships { get; set; }
    public DbSet<Location> Locations { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(ProgrammingInternshipPlatformDbContext)));
    }
}