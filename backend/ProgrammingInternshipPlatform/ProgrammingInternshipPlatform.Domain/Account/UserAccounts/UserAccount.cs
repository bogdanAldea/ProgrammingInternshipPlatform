﻿using ProgrammingInternshipPlatform.Domain.Organisation.Companies;

namespace ProgrammingInternshipPlatform.Domain.Account.UserAccounts;

public class UserAccount
{
    public AccountId Id { get; private set; }
    public Guid IdentityId { get; private set; }
    public CompanyId CompanyId { get; private set; }
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string? PictureUrl { get; private set; }
    public DateTime JoiningDate { get; private set; } = DateTime.Today;

    public static async Task<UserAccount> CreateNew(string firstName, string lastName,
        Guid identityId, CompanyId companyId, CancellationToken cancellationToken)
    {
        var userAccountValidator = new UserAccountValidator();
        var userAccount = new UserAccount
        {
            Id = new AccountId(Guid.NewGuid()),
            IdentityId = identityId,
            CompanyId = companyId,
            FirstName = firstName,
            LastName = lastName,
        };
        await userAccountValidator.ValidateDomainModelAsync(userAccount, cancellationToken);
        return userAccount;
    }
    
    public static async Task<UserAccount> CreateNew(string firstName, string lastName, string? pictureUrl,
        Guid identityId, CancellationToken cancellationToken)
    {
        var userAccountValidator = new UserAccountSignUpValidator();
        var userAccount = new UserAccount
        {
            Id = new AccountId(Guid.NewGuid()),
            IdentityId = identityId,
            FirstName = firstName,
            LastName = lastName,
            PictureUrl = pictureUrl,
        };
        await userAccountValidator.ValidateDomainModelAsync(userAccount, cancellationToken);
        return userAccount;
    }
}