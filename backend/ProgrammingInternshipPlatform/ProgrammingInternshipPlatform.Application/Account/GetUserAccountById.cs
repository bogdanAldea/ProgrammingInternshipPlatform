using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.Account.UserAccounts;

namespace ProgrammingInternshipPlatform.Application.Account;

public record GetUserAccountById(AccountId AccountId) : IRequest<HandlerResult<UserAccount>>;

public class GetUserAccountByIdHandler : IRequestHandler<GetUserAccountById, HandlerResult<UserAccount>>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public GetUserAccountByIdHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }
    
    public async Task<HandlerResult<UserAccount>> Handle(GetUserAccountById request, CancellationToken cancellationToken)
    {
        var userAccount = await GetUserAccount(request.AccountId, cancellationToken);
        if (userAccount is null)
        {
            return HandleUserAccountNotFoundError();
        }
        return HandlerResult<UserAccount>.Success(userAccount);
    }

    private async Task<UserAccount?> GetUserAccount(AccountId accountId, CancellationToken cancellationToken)
    {
        return await _context.UserAccount.FirstOrDefaultAsync(account 
            => account.Id == accountId, cancellationToken);
    }

    private HandlerResult<UserAccount> HandleUserAccountNotFoundError()
    {
        var userAccountNotFoundError =
            ApplicationError.NotFoundFailure(ApplicationErrorMessages.UserAccount.UserAccountNotFound);
        return HandlerResult<UserAccount>.Fail(userAccountNotFoundError);
    }
}