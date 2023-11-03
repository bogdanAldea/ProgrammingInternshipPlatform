using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Application.Abstractions.GraphApi;
using ProgrammingInternshipPlatform.Application.Abstractions.Handlers;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.InternshipManagement.QueryParams;
using ProgrammingInternshipPlatform.Application.InternshipManagement.Responses;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Dal.Paginator;
using ProgrammingInternshipPlatform.Dal.Queries.Internships;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships.Enums;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships.Models;

namespace ProgrammingInternshipPlatform.Application.InternshipManagement.GetAllInternshipsInAtOrganisation;

public record GetAllInternshipsAtOrganisationQuery(InternshipQueryParams QueryParams) : IApplicationRequest<Pagination<InternshipWithCoordinator>, object>;

public class GetAllInternshipsAtOrganisationHandler : 
    IApplicationHandler<GetAllInternshipsAtOrganisationQuery, Pagination<InternshipWithCoordinator>, object>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;
    private readonly IAccountsService _accountsService;

    public GetAllInternshipsAtOrganisationHandler(ProgrammingInternshipPlatformDbContext context, IAccountsService accountsService)
    {
        _context = context;
        _accountsService = accountsService;
    }
    
    public async Task<HandlerResult<Pagination<InternshipWithCoordinator>, object>> Handle(GetAllInternshipsAtOrganisationQuery request, 
        CancellationToken cancellationToken)
    {
        try
        {
            var accounts = await _accountsService.GetAllAccounts();
            var internship = _context.Internships
                .FilterByStatus(request.QueryParams.InternshipStatus)
                .FilterByScheduledStartDate(request.QueryParams.ScheduledStartDate)
                .FilterByEstimatedGraduationDate(request.QueryParams.EstimatedGraduationDate)
                .AsEnumerable()
                .Join(accounts,
                    internship => internship.CoordinatorId,
                    coordinator => coordinator.Id,
                    (internship, coordinator) => new
                    {
                        Internship = internship,
                        Coordinator = coordinator
                    })
                .Select(internshipWithCoordinator =>
                    InternshipWithCoordinator.CreateFromResult(internshipWithCoordinator.Internship,
                        internshipWithCoordinator.Coordinator))
                .ToImmutableList();

            var paginated = ContextPagination.Paginate(queryable: internship, 
                page: request.QueryParams.page, itemsPerPage: request.QueryParams.resultsPerPage);
            
            return HandlerResult<Pagination<InternshipWithCoordinator>, object>.ReadSuccessful(paginated);
        }
        catch (Exception exception)
        {
           return HandlerResult<Pagination<InternshipWithCoordinator>, object>.InternalServerFailure(exception);
        }
    }
}