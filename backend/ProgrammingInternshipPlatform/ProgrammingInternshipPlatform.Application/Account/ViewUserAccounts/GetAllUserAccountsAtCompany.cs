using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Application.Account.Contracts;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
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
        var companyExists = await _context.Companies
            .AnyAsync(company => company.Id == new CompanyId(request.CompanyId), cancellationToken);

        if (!companyExists)
        {
            var companyNotFoundErrorMessage = ApplicationErrorMessages.Company.CompanyNotFound;
            var companyNotFoundError = ApplicationError.NotFoundFailure(companyNotFoundErrorMessage);
            return HandlerResult<IReadOnlyList<UserAccountWIthRoles>>.Fail(companyNotFoundError);
        }
        
        var allAccounts = _context.UserAccount
            .Where(account => account.CompanyId == new CompanyId(request.CompanyId))
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
        return HandlerResult<IReadOnlyList<UserAccountWIthRoles>>.Success(allAccounts);
    }
}