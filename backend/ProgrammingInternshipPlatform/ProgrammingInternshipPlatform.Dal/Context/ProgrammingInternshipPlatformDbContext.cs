using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Topics.Models;
using ProgrammingInternshipPlatform.Domain.Shared.DomainEventHandling;
using Module = ProgrammingInternshipPlatform.Domain.ModuleManagement.Models.Module;

namespace ProgrammingInternshipPlatform.Dal.Context;

public class ProgrammingInternshipPlatformDbContext : DbContext
{
    public ProgrammingInternshipPlatformDbContext() {}
    public ProgrammingInternshipPlatformDbContext(DbContextOptions<ProgrammingInternshipPlatformDbContext> options) :
        base(options) {}
    
    public DbSet<Topic> Topics { get; set; } = null!;
    public DbSet<Module> Modules { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var efCoreConfigAssembly = Assembly.GetAssembly(typeof(ProgrammingInternshipPlatformDbContext));
        if (efCoreConfigAssembly is null) 
            throw new NullReferenceException();
        
        modelBuilder.Ignore<DomainEvent>();
        modelBuilder.ApplyConfigurationsFromAssembly(efCoreConfigAssembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=ROMOB41181\\SQLEXPRESS01;Database=prog-internship-platform-dev;Trusted_Connection=True;TrustServerCertificate=True;"
        );
    }
}