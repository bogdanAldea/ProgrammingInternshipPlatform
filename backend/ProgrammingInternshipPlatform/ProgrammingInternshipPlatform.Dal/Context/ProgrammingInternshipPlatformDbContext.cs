using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Models;

namespace ProgrammingInternshipPlatform.Dal.Context;

public class ProgrammingInternshipPlatformDbContext : DbContext
{
    public ProgrammingInternshipPlatformDbContext() : base() {}

    public ProgrammingInternshipPlatformDbContext(DbContextOptions<ProgrammingInternshipPlatformDbContext> options) :
        base(options) {}

    public DbSet<Internship> Internships { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(ProgrammingInternshipPlatformDbContext)));
    }
}