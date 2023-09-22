using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.Abstracts;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Lesson.Identifier;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.LearningResources.Enums;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.LearningResources.Identifiers;

namespace ProgrammingInternshipPlatform.Domain.GeneralCurriculum.LearningResources.Models;

public class LearningResource : IDeepCloneable<LearningResource>
{
    public LearningResourceId LearningResourceId { get; private set; } = new LearningResourceId(Guid.NewGuid());
    public LessonId LessonId { get; private set; }
    public LearningResourceType LearningResourceType { get; private set; }
    public string Url { get; private set; } = null!;
    public LearningResource Clone()
    {
        return new LearningResource
        {
            LearningResourceId = new LearningResourceId(Guid.NewGuid()),
            LessonId = this.LessonId,
            LearningResourceType = this.LearningResourceType,
            Url = this.Url
        };
    }
}