using ProgrammingInternshipPlatform.Domain.ModuleManagement.Models;

namespace ProgrammingInternshipPlatform.Application.GeneralCurriculumManagement.Responses;

public class LatestModuleVersion
{
    public Guid ModuleId { get; private set; }
    public string VersionNumber { get; private set; } = null!;

    public static LatestModuleVersion CreateFromVersionedModule(Module module)
        => new()
        {
            ModuleId = module.ModuleId.Value,
            VersionNumber = module.VersionNumber
        };
}