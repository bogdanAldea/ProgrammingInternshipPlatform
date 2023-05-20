using ProgrammingInternshipPlatform.Domain.Curriculum.Lessons;

namespace ProgrammingInternshipPlatform.Domain.Curriculum.Assignments;

public class Assignment
{
    public AssignmentId AssignmentId { get; private set; }
    public LessonId LessonId { get; private set; }
    public string Description { get; set; } = null!;
}