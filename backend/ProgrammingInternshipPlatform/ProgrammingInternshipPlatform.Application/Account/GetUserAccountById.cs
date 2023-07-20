using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Application.Account.Contracts;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.Account.UserAccounts;

namespace ProgrammingInternshipPlatform.Application.Account;

public record GetUserAccountById(AccountId AccountId) : IRequest<HandlerResult<UserAccountWIthRoles>>;

public class GetUserAccountByIdHandler : IRequestHandler<GetUserAccountById, HandlerResult<UserAccountWIthRoles>>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public GetUserAccountByIdHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }
    
    public async Task<HandlerResult<UserAccountWIthRoles>> Handle(GetUserAccountById request, CancellationToken cancellationToken)
    {
        var userAccount = await GetUserAccount(request.AccountId, cancellationToken);
        if (userAccount is null)
        {
            return HandleUserAccountNotFoundError();
        }
        return HandlerResult<UserAccountWIthRoles>.Success(userAccount);
    }

    private async Task<UserAccountWIthRoles?> GetUserAccount(AccountId accountId, CancellationToken cancellationToken)
    {
        /*return await _context.UserAccount.FirstOrDefaultAsync(account 
            => account.Id == accountId, cancellationToken);*/

        /*return await _context.UserAccount
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
            .SingleOrDefaultAsync(account => account.Id == accountId.Value, cancellationToken);*/

        var userAccount = await _context.UserAccount
            .Where(account => account.Id == accountId)
            .Select(account => new UserAccountWIthRoles
            {
                Id = account.Id.Value,
                FirstName = account.FirstName,
                LastName = account.LastName,
                IdentityId = account.IdentityId,
                JoiningDate = account.JoiningDate,
                PictureUrl = account.PictureUrl
            })
            .SingleOrDefaultAsync(cancellationToken);

        if (userAccount is null) return null;

        userAccount.Roles = await _context.UserRoles
            .Where(role => role.UserId == userAccount.IdentityId.ToString())
            .Join(_context.Roles,
                userRole => userRole.RoleId,
                role => role.Id,
                (_, role) => new UserAccountRole
                {
                    Name = role.Name,
                    Id = role.Id
                })
            .ToListAsync(cancellationToken);

        return userAccount;
    }

    private HandlerResult<UserAccountWIthRoles> HandleUserAccountNotFoundError()
    {
        var userAccountNotFoundError =
            ApplicationError.NotFoundFailure(ApplicationErrorMessages.UserAccount.UserAccountNotFound);
        return HandlerResult<UserAccountWIthRoles>.Fail(userAccountNotFoundError);
    }
}