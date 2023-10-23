using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.Topics.Models;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Models;

namespace ProgrammingInternshipPlatform.Dal.Context;

public class ProgrammingInternshipPlatformDbContext : DbContext
{
    public ProgrammingInternshipPlatformDbContext()
    {}

    public ProgrammingInternshipPlatformDbContext(DbContextOptions<ProgrammingInternshipPlatformDbContext> options) :
        base(options) {}

    public DbSet<Internship> Internships { get; set; } = null!;
    public DbSet<Topic> Topics { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var efCoreConfigAssembly = Assembly.GetAssembly(typeof(ProgrammingInternshipPlatformDbContext));
        if (efCoreConfigAssembly is not null)
            modelBuilder.ApplyConfigurationsFromAssembly(efCoreConfigAssembly);
    }

    /*private Assembly? GetAssemblyForEfCoreConfigurations()
        => Assembly.GetAssembly(typeof(ProgrammingInternshipPlatformDbContext));*/
}