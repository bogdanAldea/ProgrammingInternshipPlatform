using MediatR;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.Account.UserAccount;
using ProgrammingInternshipPlatform.Domain.Locations.Identifiers;

namespace ProgrammingInternshipPlatform.Application.Account;

public record RegisterAsAdminCommand(string FirstName, string LastName, string Email, string Password,
    CompanyId CompanyId, string? PictureUrl) : IRequest<HandlerResult<UserAccount>>;

public class RegisterAsAdminHandler : IRequestHandler<RegisterAsAdminCommand, HandlerResult<UserAccount>>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public RegisterAsAdminHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }
    
    public Task<HandlerResult<UserAccount>> Handle(RegisterAsAdminCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
