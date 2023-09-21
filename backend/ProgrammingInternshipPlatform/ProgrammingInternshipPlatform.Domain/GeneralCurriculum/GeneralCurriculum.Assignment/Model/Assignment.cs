using ProgrammingInternshipPlatform.Domain.Accounts.Identifiers;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.Abstracts;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Assignment.Identifiers;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Lesson.Identifier;

namespace ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Assignment.Model;

public class Assignment : IDeepCloneable<Assignment>
{
    public AssignmentId AssignmentId { get; private set; }
    public LessonId LessonId { get; private set; }
    public AccountId LastUpdatedByAccount { get; private set; }
    public DateTime? LastUpdatedOn { get; private set; }
    public string Title { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public Assignment Clone()
    {
        var clone = new Assignment
        {
            AssignmentId = new AssignmentId(Guid.NewGuid()),
            LessonId = this.LessonId,
            LastUpdatedOn = this.LastUpdatedOn,
            LastUpdatedByAccount = this.LastUpdatedByAccount,
            Title = this.Title,
            Description = this.Description
        };
        return clone;
    }
}