using FluentValidation;
using ProgrammingInternshipPlatform.Domain.Shared.Validators;

namespace ProgrammingInternshipPlatform.Domain.Account.UserAccount;

public class UserAccountValidator : DomainAbstractValidator<UserAccount>
{
    public UserAccountValidator()
    {
        RuleFor(account => account.Id)
            .NotEmpty();

        RuleFor(account => account.CompanyId)
            .NotEmpty();

        RuleFor(account => account.IdentityId)
            .NotEmpty();

        RuleFor(account => account.FirstName)
            .NotEmpty();

        RuleFor(account => account.LastName)
            .NotEmpty();

        RuleFor(account => account.JoiningDate)
            .NotEmpty()
            .Must(joiningDate => joiningDate.Equals(DateTime.Today));

    }
}