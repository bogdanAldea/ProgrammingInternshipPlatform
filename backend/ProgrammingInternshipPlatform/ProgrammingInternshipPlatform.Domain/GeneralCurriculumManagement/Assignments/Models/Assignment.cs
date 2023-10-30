using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Abstractions;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Assignments.Validators;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Lessons.Models;

namespace ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Assignments.Models;

public class Assignment : IDeepCloneable<Assignment>
{
    private Assignment(string title, string description, LessonId lessonId)
    {
        Title = title;
        Description = description;
        LessonId = lessonId;
    }

    private static AssignmentValidator _validator = new();

    public AssignmentId AssignmentId { get; private set; } = new AssignmentId(Guid.NewGuid());
    public LessonId LessonId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }

    public static async Task<Assignment> CreateNew(string title, string description, LessonId lessonId,
        CancellationToken cancellationToken)
    {
        var assignment = new Assignment(title: title, description: description, lessonId: lessonId);
        await _validator.ValidateDomainModelAsync(assignment, cancellationToken);
        return assignment;
    }

    public async Task<Assignment> Clone(CancellationToken cancellationToken)
    {
        var versionedAssignment =
            new Assignment(title: this.Title, description: this.Description, lessonId: this.LessonId);
        await _validator.ValidateDomainModelAsync(versionedAssignment, cancellationToken);
        return versionedAssignment;
    }
}