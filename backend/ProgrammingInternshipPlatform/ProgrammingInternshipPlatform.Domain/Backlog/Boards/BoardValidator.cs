using FluentValidation;
using ProgrammingInternshipPlatform.Domain.Shared.Validators;

namespace ProgrammingInternshipPlatform.Domain.Backlog.Boards;

public class BoardValidator : DomainAbstractValidator<Board>
{
    public BoardValidator()
    {
        RuleFor(board => board.BoardId)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.BoardMessages.EmptyOrNullProperty);

        RuleFor(board => board.ProjectId)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.BoardMessages.EmptyOrNullProperty);

        RuleFor(board => board.OwnerIntern)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.BoardMessages.EmptyOrNullProperty);
    }
}