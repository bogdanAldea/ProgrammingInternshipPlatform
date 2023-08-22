using FluentValidation;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Models;
using ProgrammingInternshipPlatform.Domain.Shared.Validators;

namespace ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Validators;

public class InternshipSetupValidator : DomainAbstractValidator<Internship>
{
    public InternshipSetupValidator()
    {
        RuleFor(internship => internship.Center)
            .NotEmpty();

        RuleFor(internship => internship.DurationInMonths)
            .GreaterThanOrEqualTo(3)
            .NotEmpty();

        RuleFor(internship => internship.MaxInternsToEnroll)
            .GreaterThanOrEqualTo(3)
            .NotEmpty();

        RuleFor(internship => internship.ScheduledToStartOn)
            .GreaterThanOrEqualTo(DateTime.Today)
            .NotEmpty();

        RuleFor(internship => internship.EstimatedToEndOn)
            .NotEmpty();
    }
}