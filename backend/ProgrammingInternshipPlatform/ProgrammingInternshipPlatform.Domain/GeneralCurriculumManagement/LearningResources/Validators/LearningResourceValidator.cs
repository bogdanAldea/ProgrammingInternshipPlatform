using FluentValidation;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.LearningResources.Models;
using ProgrammingInternshipPlatform.Domain.Shared.Validators;

namespace ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.LearningResources.Validators;

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