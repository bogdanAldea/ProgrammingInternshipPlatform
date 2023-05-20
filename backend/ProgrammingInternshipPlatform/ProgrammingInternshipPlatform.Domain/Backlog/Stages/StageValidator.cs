using FluentValidation;
using ProgrammingInternshipPlatform.Domain.Shared.Validators;

namespace ProgrammingInternshipPlatform.Domain.Backlog.Stages;

public class StageValidator : DomainAbstractValidator<Stage>
{
    public StageValidator()
    {
        RuleFor(stage => stage.StageId)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.StageMessages.EmptyOrNullProperty);

        RuleFor(stage => stage.BoardId)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.StageMessages.EmptyOrNullProperty);

        RuleFor(stage => stage.Title)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.StageMessages.EmptyOrNullProperty);

        RuleFor(stage => stage.Order)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.StageMessages.EmptyOrNullProperty);
    }
}