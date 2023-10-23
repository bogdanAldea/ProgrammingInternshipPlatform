using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.Abstractions;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.LearningResources.Enums;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.LearningResources.Validators;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.Lessons.Models;

namespace ProgrammingInternshipPlatform.Domain.GeneralCurriculum.LearningResources.Models;

public class LearningResource : IDeepCloneable<LearningResource>
{
    private LearningResource(LessonId lessonId, ResourceType resourceType, string url)
    {
        LessonId = lessonId;
        ResourceType = resourceType;
        Url = url;
    }

    private static LearningResourceValidator _validator = new();

    public LearningResourceId LearningResourceId { get; private set; } = new(Guid.NewGuid());
    public LessonId LessonId { get; private set; }
    public ResourceType ResourceType { get; private set; }
    public string Url { get; private set; }

    public static async Task<LearningResource> CreateNew(LessonId lessonId, ResourceType resourceType, string url,
        CancellationToken cancellationToken)
    {
        var learningResource = new LearningResource(lessonId: lessonId, resourceType: resourceType, url: url);
        await _validator.ValidateDomainModelAsync(learningResource, cancellationToken);
        return learningResource;
    }

    public async Task<LearningResource> Clone(CancellationToken cancellationToken)
    {
        var versionedLearningResource = new LearningResource(lessonId: this.LessonId, resourceType: this.ResourceType, url: this.Url);
        await _validator.ValidateDomainModelAsync(versionedLearningResource, cancellationToken);
        return versionedLearningResource;
    }
}