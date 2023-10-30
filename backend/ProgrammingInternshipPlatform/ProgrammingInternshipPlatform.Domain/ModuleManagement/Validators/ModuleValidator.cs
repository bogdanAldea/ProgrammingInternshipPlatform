using FluentValidation;
using ProgrammingInternshipPlatform.Domain.ModuleManagement.Models;
using ProgrammingInternshipPlatform.Domain.Shared.Validators;

namespace ProgrammingInternshipPlatform.Domain.ModuleManagement.Validators;

public class ModuleValidator : DomainAbstractValidator<Module>
{
    public ModuleValidator()
    {
        RuleFor(module => module.ModuleId)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.PropertyMustExist);

        RuleFor(module => module.TopicId)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.PropertyMustExist);

        RuleFor(module => module.VersionedByUser)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage(RuleFailureMessages.PropertyMustExist);

        RuleFor(module => module.VersionedOnDate)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.PropertyMustExist);

        RuleFor(module => module.VersionNumber)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage(RuleFailureMessages.PropertyMustExist);
    }
}