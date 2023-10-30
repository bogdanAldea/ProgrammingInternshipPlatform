using FluentValidation;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Assignments.Validators;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Lessons.Models;
using ProgrammingInternshipPlatform.Domain.Shared.Validators;

namespace ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Lessons.Validators;

public static class LessonRuleSets
{
    public const string General = "General";
    public const string AddAssignment = "Add Assignment";
    public const string Versioning = "Versioning";
}

public class LessonValidator : DomainAbstractValidator<Lesson>
{
    public LessonValidator()
    {
        SetGeneralRules();
        SetForAddAssignment();
        SetForVersioning();
    }

    private void SetGeneralRules()
    {
        RuleSet(LessonRuleSets.General, () =>
        {
            RuleFor(lesson => lesson.LessonId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(RuleFailureMessages.PropertyMustExist);
        
            RuleFor(lesson => lesson.TopicId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(RuleFailureMessages.PropertyMustExist);

            RuleFor(lesson => lesson.Title)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(RuleFailureMessages.PropertyMustExist)
                .MaximumLength(RuleConstants.GeneralCurriculum.TopicTitleMaxLength)
                .WithMessage(RuleFailureMessages.PropertyLenghtTooLong);
        
            RuleFor(lesson => lesson.Description)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(RuleFailureMessages.PropertyMustExist)
                .MaximumLength(RuleConstants.GeneralCurriculum.TopicDescriptionMaxLength)
                .WithMessage(RuleFailureMessages.PropertyLenghtTooLong);

            RuleFor(lesson => lesson.TopicOrder)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(RuleFailureMessages.PropertyMustExist)
                .GreaterThanOrEqualTo(RuleConstants.PositiveValue)
                .WithMessage(RuleFailureMessages.PropertyMustBePositiveNumber);
        });
    }

    private void SetForAddAssignment()
    {
        RuleSet(LessonRuleSets.AddAssignment, () =>
        {
            RuleFor(lesson => lesson.Assignment)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(RuleFailureMessages.PropertyMustExist);

            RuleFor(lesson => lesson.Assignment)
                .SetValidator(new AssignmentValidator()!)
                .When(lesson => lesson.Assignment != null);
        });
    }

    private void SetForVersioning()
    {
        RuleSet(LessonRuleSets.Versioning, () =>
        {
            RuleFor(lesson => lesson.Assignment)
                .NotNull().WithMessage(RuleFailureMessages.PropertyMustExist);

            RuleFor(lesson => lesson.LearningResources)
                .NotEmpty().WithMessage(RuleFailureMessages.CollectionMustNotBeEmpty);
        });
    }
}