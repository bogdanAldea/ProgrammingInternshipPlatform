using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Application.Account.Contracts;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.Account.UserAccounts;
using ProgrammingInternshipPlatform.Domain.Organisation.Companies;

namespace ProgrammingInternshipPlatform.Application.Account.ViewUserAccounts;

public record GetAllUserAccountsAtCompanyQuery(Guid CompanyId) : IRequest<HandlerResult<IReadOnlyList<UserAccountWIthRoles>>>;

public class GetAllUserAccountsAtCompanyHandler :
    IRequestHandler<GetAllUserAccountsAtCompanyQuery, HandlerResult<IReadOnlyList<UserAccountWIthRoles>>>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public GetAllUserAccountsAtCompanyHandler(
        ProgrammingInternshipPlatformDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<HandlerResult<IReadOnlyList<UserAccountWIthRoles>>> Handle(GetAllUserAccountsAtCompanyQuery request,
        CancellationToken cancellationToken)
    {
        var companyExists = await CheckIfOrganisationExists(request.CompanyId, cancellationToken);

        if (!companyExists)
        {
            return HandlerResultFailureHelper.NotFoundFailure<IReadOnlyList<UserAccountWIthRoles>>(
                ApplicationErrorMessages.Company.CompanyNotFound);
        }

        var allAccounts = GetAllAccountsAtOrganisation(request.CompanyId);
        return HandlerResult<IReadOnlyList<UserAccountWIthRoles>>.Success(allAccounts);
    }

    private async Task<bool> CheckIfOrganisationExists(Guid companyId, CancellationToken cancellationToken)
    {
        return await _context.Companies
            .AnyAsync(company => company.Id == new CompanyId(companyId), cancellationToken);
    }

    private List<UserAccountWIthRoles> GetAllAccountsAtOrganisation(Guid companyId)
    {
        return _context.UserAccount
            .Where(account => account.CompanyId == new CompanyId(companyId))
            .Select(account => new UserAccountWIthRoles
            {
                Id = account.Id.Value,
                FirstName = account.FirstName,
                LastName = account.LastName,
                IdentityId = account.IdentityId,
                JoiningDate = account.JoiningDate,
                PictureUrl = account.PictureUrl,
                Roles = _context.UserRoles
                    .Where(role => role.UserId == account.IdentityId.ToString())
                    .Join(_context.Roles,
                        user => user.RoleId,
                        role => role.Id,
                        (_, role) => new UserAccountRole
                        {
                            Name = role.Name,
                            Id = role.Id
                        })
                    .ToList()
            })
            .ToList();
    }
}