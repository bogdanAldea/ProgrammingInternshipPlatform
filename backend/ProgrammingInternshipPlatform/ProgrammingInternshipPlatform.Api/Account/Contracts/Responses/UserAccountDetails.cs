using Microsoft.AspNetCore.Identity;
using ProgrammingInternshipPlatform.Domain.Account.UserAccounts;

namespace ProgrammingInternshipPlatform.Api.Account.Contracts.Responses;

public class UserAccountDetails
{
    public Guid Id { get; private set; }
    public Guid IdentityId { get; private set; }
    public Guid CompanyId { get; private set; }
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string? PictureUrl { get; private set; }
    public DateTime JoiningDate { get; private set; }

    public static UserAccountDetails MapFromUserAccount(UserAccount userAccount)
    {
        return new UserAccountDetails
        {
            Id = userAccount.Id.Value,
            IdentityId = userAccount.IdentityId,
            CompanyId = userAccount.CompanyId.Value,
            FirstName = userAccount.FirstName,
            LastName = userAccount.LastName,
            PictureUrl = userAccount.PictureUrl,
            JoiningDate = userAccount.JoiningDate
        };
    }
}