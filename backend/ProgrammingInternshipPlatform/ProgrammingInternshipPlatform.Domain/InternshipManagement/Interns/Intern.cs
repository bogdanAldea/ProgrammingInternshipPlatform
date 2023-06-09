using ProgrammingInternshipPlatform.Domain.Account.UserAccounts;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships;

namespace ProgrammingInternshipPlatform.Domain.InternshipManagement.Interns;

public class Intern
{
    private static readonly InternValidator Validator = new();
    public Intern() {}
    
    public InternId Id { get; private set; }
    public AccountId AccountId { get; private set; }
    public InternshipId InternshipId { get; private set; }

    public static async Task<Intern> CreateNew(AccountId accountId, InternshipId internshipId, CancellationToken cancellationToken)
    {
        var intern = new Intern
        {
            Id = new InternId(Guid.NewGuid()),
            AccountId = accountId,
            InternshipId = internshipId
        };

        await Validator.ValidateDomainModelAsync(intern, cancellationToken);
        return intern;
    }
}