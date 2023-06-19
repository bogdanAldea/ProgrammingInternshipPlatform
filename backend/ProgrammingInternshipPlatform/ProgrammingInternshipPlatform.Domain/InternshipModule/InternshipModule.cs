using ProgrammingInternshipPlatform.Domain.Curriculum.Modules;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships;

namespace ProgrammingInternshipPlatform.Domain.InternshipModule;

public class InternshipModule
{
    public InternshipModuleId InternshipModuleId { get; private set; }
    public InternshipId InternshipId { get; private set; }
    public ModuleId ModuleId { get; private set; }
}