using ProgrammingInternshipPlatform.Application.Abstractions.Handlers;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.Helpers.EnumRetrieval;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Enums;

namespace ProgrammingInternshipPlatform.Application.Centers.GetAllCenters;

public record GetAllCentersQuery : IApplicationCollectionRequest<Converted<Center>>;

public class GetAllCentersHandler : IApplicationCollectionHandler<GetAllCentersQuery, Converted<Center>>
{
    public Task<HandlerResult<IReadOnlyList<Converted<Center>>>> Handle(GetAllCentersQuery request, CancellationToken cancellationToken)
    {
        var allCenters = EnumRetrievalHelper.GetAllEnumValues<Center>();
        return Task.FromResult(HandlerResult<IReadOnlyList<Converted<Center>>>.Success(allCenters));
    }
}