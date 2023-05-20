using ProgrammingInternshipPlatform.Domain.LearningHub.AssignmentRequests;

namespace ProgrammingInternshipPlatform.Domain.LearningHub.Comments;

public class Comment
{
    public CommentId CommentId { get; private set; }
    public AssignmentRequestId AssignmentRequestId { get; private set; }
    public string Message { get; private set; } = null!;
    public bool IsSolved { get; private set; } = false;
}