using ProgrammingInternshipPlatform.Domain.ModuleVersioning.VersionedModules.Model;

namespace ProgrammingInternshipPlatform.Api.GeneralCurriculum.Contracts.Responses;

public class CurrentVersionPartial
{
    public Guid CurrentVersionId { get; set; }
    public string VersionNumber { get; set; } = null!;

    public static CurrentVersionPartial CreateFromResource(VersionedModule module)
    {
        return new CurrentVersionPartial
        {
            CurrentVersionId = module.VersionedModuleId.Value,
            VersionNumber = module.VersionNumber
        };
    }
}