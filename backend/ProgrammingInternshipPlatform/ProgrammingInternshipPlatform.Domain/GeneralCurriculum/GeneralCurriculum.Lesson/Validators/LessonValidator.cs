using System.Data;
using FluentValidation;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.ValidationConstants;
using ProgrammingInternshipPlatform.Domain.Shared.Validators;

namespace ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Lesson.Validators;

public class LessonValidator : DomainAbstractValidator<Model.Lesson>
{
    public LessonValidator()
    {
        RuleFor(lesson => lesson.LessonId)
            .NotEmpty().WithMessage("");

        RuleFor(lesson => lesson.ChapterId)
            .NotEmpty().WithMessage("");

        RuleFor(lesson => lesson.Title)
            .NotEmpty().WithMessage("")
            .MaximumLength(ChapterValidationConstants.LessonTitleLength).WithMessage("");

        RuleFor(lesson => lesson.Description)
            .NotEmpty().WithMessage("")
            .MaximumLength(ChapterValidationConstants.LessonDescriptionLength);
        
        RuleFor(lesson => lesson.LearningObjective)
            .NotEmpty().WithMessage("")
            .MaximumLength(ChapterValidationConstants.LessonLearningObjectiveLenght);
    }
}