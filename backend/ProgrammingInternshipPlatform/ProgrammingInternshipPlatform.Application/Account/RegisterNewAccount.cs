using MediatR;
using Microsoft.AspNetCore.Identity;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.Account.UserAccount;

namespace ProgrammingInternshipPlatform.Application.Account;

public record RegisterNewAccountCommand(string FirstName, string LastName, string Email, string Password, string? PictureUrl) 
    : IRequest<HandlerResult<UserAccount>>;

public class RegisterNewAccountHandler : IRequestHandler<RegisterNewAccountCommand, HandlerResult<UserAccount>>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public RegisterNewAccountHandler(ProgrammingInternshipPlatformDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }
    
    public Task<HandlerResult<UserAccount>> Handle(RegisterNewAccountCommand request, CancellationToken cancellationToken)
    {
        // check if identity exists for given email
            // return failure if does
            
        // create identity user
            // validate created identity
            
        // create user account profile
            // expect domain exception if validation fails    
        
        // if one failed => roll back transaction
        throw new NotImplementedException();
    }
}
    