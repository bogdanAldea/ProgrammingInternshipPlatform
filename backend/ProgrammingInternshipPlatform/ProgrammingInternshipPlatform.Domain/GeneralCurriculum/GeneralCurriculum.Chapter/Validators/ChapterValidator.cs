using FluentValidation;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.ValidationConstants;
using ProgrammingInternshipPlatform.Domain.Shared.Validators;

namespace ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Validators;

public class ChapterValidator : DomainAbstractValidator<Models.Chapter>
{
    public ChapterValidator()
    {
        RuleFor(chapter => chapter.ChapterId)
            .NotEmpty()
                .WithMessage(ChapterRuleFailureMessages.IdNullOrEmpty);

        RuleFor(chapter => chapter.Description)
            .MaximumLength(ChapterValidationConstants.ChapterDescriptionLenght)
                .WithMessage(ChapterRuleFailureMessages.ChapterDescriptionTooLong)
            .NotEmpty()
                .WithMessage(ChapterRuleFailureMessages.ChapterDescriptionNotProvided);
    }
}