﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Application.Account.Contracts;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;

namespace ProgrammingInternshipPlatform.Application.Account;

public record GetAllRolesQuery : IRequest<HandlerResult<IReadOnlyList<UserAccountRole>>>;

public class GetAllRolesHandler : IRequestHandler<GetAllRolesQuery, HandlerResult<IReadOnlyList<UserAccountRole>>>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public GetAllRolesHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }
    
    public async Task<HandlerResult<IReadOnlyList<UserAccountRole>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        var allRoles = await _context.Roles
            .Select(role => new UserAccountRole
            {
                Name = role.Name,
                Id = role.Id
            })
            .ToListAsync(cancellationToken);
        return HandlerResult<IReadOnlyList<UserAccountRole>>.Success(allRoles);
    }   
}