using ProgrammingInternshipPlatform.Domain.Locations.Identifiers;

namespace ProgrammingInternshipPlatform.Domain.Account.UserAccount;

public class UserAccount
{
    public AccountId Id { get; private set; }
    public Guid IdentityId { get; private set; }
    public CompanyId CompanyId { get; private set; }
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string? PictureUrl { get; private set; }
    public DateTime JoiningDate { get; private set; } = DateTime.Today;

    public static async Task<UserAccount> CreateNew(string firstName, string lastName, string? pictureUrl,
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
            PictureUrl = pictureUrl,
        };
        await userAccountValidator.ValidateDomainModelAsync(userAccount, cancellationToken);
        return userAccount;
    }
}