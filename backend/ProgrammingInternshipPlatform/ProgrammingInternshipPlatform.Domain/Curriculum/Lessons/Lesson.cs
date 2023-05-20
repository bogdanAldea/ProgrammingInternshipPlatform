using ProgrammingInternshipPlatform.Domain.Curriculum.Assignments;
using ProgrammingInternshipPlatform.Domain.Curriculum.Modules;

namespace ProgrammingInternshipPlatform.Domain.Curriculum.Lessons;

public class Lesson
{
    public LessonId LessonId { get; private set; }
    public ModuleId ModuleId { get; private set; }
    public Assignment Assignment { get; private set; } = null!;
    public string Title { get; private set; } = null!;
    public string Description { get; private set; } = null!;
}