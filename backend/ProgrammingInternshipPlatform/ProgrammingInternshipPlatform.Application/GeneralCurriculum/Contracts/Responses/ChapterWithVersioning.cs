namespace ProgrammingInternshipPlatform.Application.GeneralCurriculum.Contracts.Responses;

public class ChapterWithVersioning
{
    public Guid ChapterId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int NumberOfLessons { get; set; }
    public int Versions { get; set; }
    public CurrentVersionPartial? CurrentVersion { get; set; }
}