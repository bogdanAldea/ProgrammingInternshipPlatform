using FluentValidation;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.LearningResources.Models;
using ProgrammingInternshipPlatform.Domain.Shared.Validators;

namespace ProgrammingInternshipPlatform.Domain.GeneralCurriculum.LearningResources.Validators;

public class LearningResourceValidator : DomainAbstractValidator<LearningResource>
{
    public LearningResourceValidator()
    {
        RuleFor(resource => resource.LearningResourceId)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.PropertyMustExist);

        RuleFor(resource => resource.LessonId)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.PropertyMustExist);

        RuleFor(resource => resource.ResourceType)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.PropertyMustExist)
            .IsInEnum()
            .WithMessage(RuleFailureMessages.PropertyMustBeAEnumValue);

        RuleFor(resource => resource.Url)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.PropertyMustExist);
    }
}