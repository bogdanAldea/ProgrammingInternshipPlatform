using ProgrammingInternshipPlatform.Application.Abstractions.Handlers;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.Helpers.EnumRetrieval;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Enums;

namespace ProgrammingInternshipPlatform.Application.TechnologiesStack;

public record GetTechnologyStackQuery : IApplicationCollectionRequest<Converted<TechnologyStack>>;

public class GetTechnologyStackHandler : IApplicationCollectionHandler<GetTechnologyStackQuery, Converted<TechnologyStack>>
{
    public Task<HandlerResult<IReadOnlyList<Converted<TechnologyStack>>>> Handle(GetTechnologyStackQuery request, CancellationToken cancellationToken)
    {
        var technologyStack = EnumRetrievalHelper.GetAllEnumValues<TechnologyStack>();
        return Task.FromResult(HandlerResult<IReadOnlyList<Converted<TechnologyStack>>>.Success(technologyStack));
    }
}