using FluentValidation;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships.Enums;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships.Models;
using ProgrammingInternshipPlatform.Domain.Shared.Validators;

namespace ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships.Validators;

public static class InternshipRuleSets
{
    public const string General = "General";
    public const string Creation = "Creation";
}

public class InternshipValidator : DomainAbstractValidator<Internship>
{
    private const string GraduationDateValidWithMonthDuration =
        "The graduation date must be equal to the scheduled date plus the specified duration in months.";

    public InternshipValidator()
    {
        SetRulesForGeneral();
        SetRulesForCreation();
    }
    
    private void SetRulesForGeneral()
    {
        RuleSet(InternshipRuleSets.General, () =>
        {
            RuleFor(internship => internship.InternshipId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(RuleFailureMessages.PropertyMustExist);

            RuleFor(internship => internship.CoordinatorId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(RuleFailureMessages.PropertyMustExist);

            RuleFor(internship => internship.DurationInMonths)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(RuleFailureMessages.PropertyMustExist);

            RuleFor(internship => internship.MaxInternsToEnroll)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(RuleFailureMessages.PropertyMustExist);

            RuleFor(internship => internship.ScheduledStartDate)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(RuleFailureMessages.PropertyMustExist);

            RuleFor(internship => internship.EstimatedGraduationDate)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(RuleFailureMessages.PropertyMustExist);

            RuleFor(internship => internship.InternshipStatus)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage(RuleFailureMessages.PropertyMustExist)
                .IsInEnum().WithMessage(RuleFailureMessages.PropertyMustBeAEnumValue);
        });
    }

    private void SetRulesForCreation()
    {
        RuleSet(InternshipRuleSets.Creation, () =>
        {
            RuleFor(internship => internship.InternshipStatus)
                .Cascade(CascadeMode.Stop)
                .Must(InternshipStatusInProgressState)
                .WithMessage(RuleFailureMessages.PropertyMustBeInValidState);

            RuleFor(internship => internship)
                .Cascade(CascadeMode.Stop)
                .Must(EstimatedGraduationDateEqualWithAddedMonthsFromScheduledStart)
                .WithMessage(GraduationDateValidWithMonthDuration);
        });
    }

    private bool InternshipStatusInProgressState(InternshipStatus status)
        => status == InternshipStatus.SetupInProgress;


    private bool EstimatedGraduationDateEqualWithAddedMonthsFromScheduledStart(Internship internship)
        => internship.EstimatedGraduationDate.Date == internship.ScheduledStartDate
                   .AddMonths(internship.DurationInMonths).Date;
}