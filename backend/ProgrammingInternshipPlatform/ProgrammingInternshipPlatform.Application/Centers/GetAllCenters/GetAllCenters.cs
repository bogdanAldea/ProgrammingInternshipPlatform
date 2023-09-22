using ProgrammingInternshipPlatform.Application.Abstractions.Handlers;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.Helpers.EnumRetrieval;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Enums;

namespace ProgrammingInternshipPlatform.Application.Centers.GetAllCenters;

public record GetAllCentersQuery : IApplicationCollectionRequest<DomainEnumConverted<Center>>;

public class GetAllCentersHandler : IApplicationCollectionHandler<GetAllCentersQuery, DomainEnumConverted<Center>>
{
    public Task<HandlerResult<IReadOnlyList<DomainEnumConverted<Center>>>> Handle(GetAllCentersQuery request, CancellationToken cancellationToken)
    {
        var allCenters = EnumRetrievalHelper.GetAllEnumValues<Center>();
        return Task.FromResult(HandlerResult<IReadOnlyList<DomainEnumConverted<Center>>>.Success(allCenters));
    }
}