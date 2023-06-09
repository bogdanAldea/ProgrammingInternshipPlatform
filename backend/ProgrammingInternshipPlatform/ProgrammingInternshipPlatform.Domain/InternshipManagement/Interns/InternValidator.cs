using FluentValidation;
using ProgrammingInternshipPlatform.Domain.Shared.Validators;

namespace ProgrammingInternshipPlatform.Domain.InternshipManagement.Interns;

public class InternValidator : DomainAbstractValidator<Intern>
{
    public InternValidator()
    {
        RuleFor(intern => intern.Id)
            .NotEmpty();

        RuleFor(intern => intern.AccountId)
            .NotEmpty();

        RuleFor(intern => intern.InternshipId)
            .NotEmpty();
    }
}