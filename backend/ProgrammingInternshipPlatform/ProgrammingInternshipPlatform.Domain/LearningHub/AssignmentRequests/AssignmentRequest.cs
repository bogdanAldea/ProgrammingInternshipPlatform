using ProgrammingInternshipPlatform.Domain.Curriculum.Assignments;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Interns;
using ProgrammingInternshipPlatform.Domain.LearningHub.Comments;
using ProgrammingInternshipPlatform.Domain.LearningHub.ScheduledPresentations;

namespace ProgrammingInternshipPlatform.Domain.LearningHub.AssignmentRequests;

public class AssignmentRequest
{
    private readonly List<Comment> _comments = new();
    public AssignmentRequestId AssignmentRequestId { get; private set; }
    public ScheduledPresentationId ScheduledPresentationId { get; private set; }
    public AssignmentId AssignmentId { get; private set; }
    public AssignmentRequestStatus Status { get; private set; }
    public InternId InternId { get; private set; }
    public DateTime Deadline { get; private set; }
    public IReadOnlyCollection<Comment> Comments => _comments;
}