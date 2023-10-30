using FluentValidation;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Lessons.Models;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Lessons.Validators;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Topics.Enums;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Topics.Models;
using ProgrammingInternshipPlatform.Domain.Shared.Validators;

namespace ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Topics.Validators;

public static class TopicRuleSets
{
    public const string General = "General";
    public const string States = "States";
    public const string LessonAdd = "Lesson Add";
    public const string LessonRemove = "Lesson Remove";
    public const string TopicUnversioned = "Topic Unversioned";
    public const string Versioning = "Versioning";
}

public class TopicValidator : DomainAbstractValidator<Topic>
{
    public TopicValidator()
    {
       SetGeneralRuleSet();
       SetForValidSateValues();
       SetForAddLesson();
       SetForRemoveLesson();
       SetForUnversionedState();
    }

    private void SetGeneralRuleSet()
    {
        RuleSet(TopicRuleSets.General, () =>
        {
            RuleFor(topic => topic.TopicId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(RuleFailureMessages.PropertyMustExist);

            RuleFor(topic => topic.Title)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(RuleFailureMessages.PropertyMustExist)
                .MaximumLength(RuleConstants.GeneralCurriculum.TopicTitleMaxLength)
                .WithMessage(RuleFailureMessages.PropertyLenghtTooLong);

            RuleFor(topic => topic.Description)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(RuleFailureMessages.PropertyMustExist)
                .MaximumLength(RuleConstants.GeneralCurriculum.TopicDescriptionMaxLength)
                .WithMessage(RuleFailureMessages.PropertyLenghtTooLong);

            RuleFor(topic => topic.SyllabusOrder)
                .NotEmpty()
                .WithMessage(RuleFailureMessages.PropertyMustExist)
                .GreaterThanOrEqualTo(RuleConstants.PositiveValue)
                .WithMessage(RuleFailureMessages.PropertyMustBePositiveNumber);
        });
    }

    private void SetForValidSateValues()
    {
        RuleSet(TopicRuleSets.States, () =>
        {
            RuleFor(topic => topic.TopicType)
                .Cascade(CascadeMode.Stop)
                .IsInEnum()
                .WithMessage(RuleFailureMessages.PropertyMustBeAEnumValue)
                .NotEmpty()
                .WithMessage(RuleFailureMessages.PropertyMustExist);

            RuleFor(topic => topic.VersioningState)
                .Cascade(CascadeMode.Stop)
                .IsInEnum()
                .WithMessage(RuleFailureMessages.PropertyMustBeAEnumValue)
                .NotEmpty()
                .WithMessage(RuleFailureMessages.PropertyMustExist);
        });
    }

    private void SetForAddLesson()
    {
        RuleSet(TopicRuleSets.LessonAdd, () =>
        {
            RuleFor(topic => topic.Lessons)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(RuleFailureMessages.PropertyMustExist);

            RuleFor(topic => topic)
                .Cascade(CascadeMode.Stop)
                .Must(TopicShouldHaveValidVersioningState)
                .WithMessage(RuleFailureMessages.PropertyMustBeInValidState);

            RuleForEach(topic => topic.Lessons)
                .Cascade(CascadeMode.Stop)
                .Must((topic, lesson) => AllLessonsShouldHaveUniqueTitle(topic.Lessons, lesson))
                .WithMessage(RuleFailureMessages.CollectionItemsMustHaveUniqueTitle)
                .SetValidator(new LessonValidator(), new []{LessonRuleSets.General, LessonRuleSets.AddAssignment});
        });
    }

    private void SetForVersioning()
    {
        RuleSet(TopicRuleSets.Versioning, () =>
        {
            RuleFor(topic => topic.Lessons)
                .HasAtLeastOneItem()
                .WithMessage(RuleFailureMessages.CollectionMustNotBeEmpty);
        });
    }

    private void SetForRemoveLesson()
    {
        RuleSet(TopicRuleSets.LessonRemove, () =>
        {
            RuleFor(topic => topic.Lessons)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(RuleFailureMessages.PropertyMustExist);
        });
    }

    private void SetForUnversionedState()
    {
        RuleSet(TopicRuleSets.TopicUnversioned, () =>
        {
            RuleFor(topic => topic.TopicType)
                .Cascade(CascadeMode.Stop)
                .Equal(TopicType.NotVersioned)
                .WithMessage(RuleFailureMessages.PropertyMustBeInValidState);
        });
    }
    
    private bool TopicShouldHaveValidVersioningState(Topic topic)
    {
        var allLessonsHaveAssignments = topic.Lessons.All(lesson => lesson.Assignment != null);
        return allLessonsHaveAssignments
            ? topic.VersioningState == VersioningState.ReadyForVersioning
            : topic.VersioningState == VersioningState.NotReadyForVersioning;
    }
    
    private bool AllLessonsShouldHaveUniqueTitle(IReadOnlyList<Lesson> lessons, Lesson lessonToValidate)
        => lessons
            .Where(lesson => lesson != lessonToValidate)
            .All(lesson => lesson.Title != lessonToValidate.Title);
}