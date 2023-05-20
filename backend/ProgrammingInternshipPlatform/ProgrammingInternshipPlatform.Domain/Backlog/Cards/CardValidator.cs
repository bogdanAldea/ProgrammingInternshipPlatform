using FluentValidation;
using ProgrammingInternshipPlatform.Domain.Shared.Validators;

namespace ProgrammingInternshipPlatform.Domain.Backlog.Cards;

public class CardValidator : DomainAbstractValidator<Card>
{
    public CardValidator()
    {
        RuleFor(card => card.CardId)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.CardMessages.EmptyOrNullProperty);
        
        RuleFor(card => card.StageId)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.CardMessages.EmptyOrNullProperty);;

        RuleFor(card => card.WorkItemId)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.CardMessages.EmptyOrNullProperty);;

        RuleFor(card => card.Status)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.CardMessages.EmptyOrNullProperty)
            .IsInEnum()
            .WithMessage(RuleFailureMessages.CardMessages.StatusNotAnEnumValue);
    }
}