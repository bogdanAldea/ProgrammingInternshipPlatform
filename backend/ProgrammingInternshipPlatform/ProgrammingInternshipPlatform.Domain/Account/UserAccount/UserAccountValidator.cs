using FluentValidation;
using ProgrammingInternshipPlatform.Domain.Shared.Validators;

namespace ProgrammingInternshipPlatform.Domain.Account.UserAccount;

public class UserAccountValidator : DomainAbstractValidator<UserAccount>
{
    public UserAccountValidator()
    {
        RuleFor(account => account.Id)
            .NotEmpty().WithMessage(RuleFailureMessages.UserAccount.EmptyOrNullProperty);

        RuleFor(account => account.CompanyId)
            .NotEmpty().WithMessage(RuleFailureMessages.UserAccount.EmptyOrNullProperty);;

        RuleFor(account => account.IdentityId)
            .NotEmpty().WithMessage(RuleFailureMessages.UserAccount.EmptyOrNullProperty);;

        RuleFor(account => account.FirstName)
            .NotEmpty().WithMessage(RuleFailureMessages.UserAccount.EmptyOrNullProperty);;

        RuleFor(account => account.LastName)
            .NotEmpty().WithMessage(RuleFailureMessages.UserAccount.EmptyOrNullProperty);;

        RuleFor(account => account.JoiningDate)
            .NotEmpty()
            .Must(joiningDate => joiningDate.Equals(DateTime.Today))
            .WithMessage(RuleFailureMessages.UserAccount.JoiningDateSetInThePast);

    }
}