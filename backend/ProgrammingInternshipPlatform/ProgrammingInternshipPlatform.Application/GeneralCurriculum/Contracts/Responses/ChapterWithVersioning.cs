using ProgrammingInternshipPlatform.Dal.Migrations;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Models;
using VersionedModule = ProgrammingInternshipPlatform.Domain.VersionedModules.Model.VersionedModule;

namespace ProgrammingInternshipPlatform.Application.GeneralCurriculum.Contracts.Responses;

public class ChapterWithVersioning
{
    public Chapter Chapter { get; set; }

    public VersionedModule? VersionedModule { get; set; }

    public int Versions { get; set; }
    /*public Guid ChapterId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int NumberOfLessons { get; set; }
    public int Versions { get; set; }
    public CurrentVersionPartial? CurrentVersion { get; set; }*/
}