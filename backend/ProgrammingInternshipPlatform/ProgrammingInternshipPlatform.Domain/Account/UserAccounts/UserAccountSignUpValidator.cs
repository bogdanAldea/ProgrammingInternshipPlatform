using FluentValidation;
using ProgrammingInternshipPlatform.Domain.Shared.Validators;

namespace ProgrammingInternshipPlatform.Domain.Account.UserAccounts;

public class UserAccountSignUpValidator : DomainAbstractValidator<UserAccount>
{
public UserAccountSignUpValidator()
{
    RuleFor(account => account.Id)
        .NotEmpty().WithMessage(RuleFailureMessages.UserAccountMessages.EmptyOrNullProperty);

    RuleFor(account => account.IdentityId)
        .NotEmpty().WithMessage(RuleFailureMessages.UserAccountMessages.EmptyOrNullProperty);;

    RuleFor(account => account.FirstName)
        .NotEmpty().WithMessage(RuleFailureMessages.UserAccountMessages.EmptyOrNullProperty);;

    RuleFor(account => account.LastName)
        .NotEmpty().WithMessage(RuleFailureMessages.UserAccountMessages.EmptyOrNullProperty);;

    RuleFor(account => account.JoiningDate)
        .NotEmpty()
        .Must(joiningDate => joiningDate.Equals(DateTime.Today))
        .WithMessage(RuleFailureMessages.UserAccountMessages.JoiningDateSetInThePast);

}
}