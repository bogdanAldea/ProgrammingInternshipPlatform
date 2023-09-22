using System.ComponentModel.DataAnnotations;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.ValidationConstants;

namespace ProgrammingInternshipPlatform.Api.GeneralCurriculum.Contracts.Requests;

public class NewLessonRequest
{
    public NewLessonRequest(Guid chapterId, string title, string description, string learningObjective)
    {
        ChapterId = chapterId;
        Title = title;
        Description = description;
        LearningObjective = learningObjective;
    }
    
    [Required]
    public Guid ChapterId { get; private set; }

    [Required]
    [MaxLength(ChapterValidationConstants.LessonTitleLength)]
    public string Title { get; private set; }
    
    [Required]
    [MaxLength(ChapterValidationConstants.LessonDescriptionLength)]
    public string Description { get; private set; }
    
    [Required]
    [MaxLength(ChapterValidationConstants.LessonLearningObjectiveLenght)]
    public string LearningObjective { get; private set; }
}