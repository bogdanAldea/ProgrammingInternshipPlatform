using ProgrammingInternshipPlatform.Domain.Curriculum.Lessons;

namespace ProgrammingInternshipPlatform.Domain.Curriculum.Modules;

public class Module
{
    private readonly List<Lesson> _lessons = new();
    public ModuleId ModuleId { get; private set; }
    public string Title { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public IReadOnlyCollection<Lesson> Lessons => _lessons;
}