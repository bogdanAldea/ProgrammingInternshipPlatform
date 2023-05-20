using ProgrammingInternshipPlatform.Domain.Curriculum.Lessons;
using ProgrammingInternshipPlatform.Domain.LearningHub.AssignmentRequests;

namespace ProgrammingInternshipPlatform.Domain.LearningHub.ScheduledPresentations;

public class ScheduledPresentation
{
    private static readonly ScheduledPresentationValidator PresentationValidator = new();
    public ScheduledPresentationId ScheduledPresentationId { get; private set; }
    public LessonId LessonId { get; private set; }
    public AssignmentRequest? AssignmentRequest { get; private set; }
    public DateTime ScheduledOn { get; private set; }
    public PresentationStatus Status { get; private set; }
}