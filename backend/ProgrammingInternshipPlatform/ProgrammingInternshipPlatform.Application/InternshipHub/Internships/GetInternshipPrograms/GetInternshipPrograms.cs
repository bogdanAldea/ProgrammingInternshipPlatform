using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProgrammingInternshipPlatform.Application.Abstractions.GraphApi;
using ProgrammingInternshipPlatform.Application.Abstractions.GraphApi.Settings;
using ProgrammingInternshipPlatform.Application.Abstractions.Handlers;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.InternshipHub.Responses;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Dal.InternshipHub;

namespace ProgrammingInternshipPlatform.Application.InternshipHub.Internships.GetInternshipPrograms;

public record GetInternshipProgramsQuery : IApplicationCollectionRequest<InternshipWithCoordinator>;

public class GetInternshipProgramsHandler : IApplicationCollectionHandler<GetInternshipProgramsQuery, InternshipWithCoordinator>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;
    private readonly IAccountsService _accountsService;
    private readonly IOptions<RoleSettings> _applicationRoles;

    public GetInternshipProgramsHandler(ProgrammingInternshipPlatformDbContext context,
        IAccountsService accountsService, IOptions<RoleSettings> applicationRoles)
    {
        _context = context;
        _accountsService = accountsService;
        _applicationRoles = applicationRoles;
    }

    public async Task<HandlerResult<IReadOnlyList<InternshipWithCoordinator>>> Handle(GetInternshipProgramsQuery request,
        CancellationToken cancellationToken)
    {
        var allInternshipPrograms = await _context.GetAllInternships().ToListAsync(cancellationToken);
        var allCoordinators = await _accountsService.GetAccountsByRole("8b56ee9e-7135-4201-9792-dcbc28d3f839");

        var mappedInternships = allInternshipPrograms
            .Select(internship => new InternshipWithCoordinator
            {
                Coordinator = allCoordinators.SingleOrDefault(coordinator => coordinator.Id == internship.CoordinatorId)!,
                Internship = internship
            })
            .ToList();

        return HandlerResult<IReadOnlyList<InternshipWithCoordinator>>.Success(mappedInternships);
    }
}