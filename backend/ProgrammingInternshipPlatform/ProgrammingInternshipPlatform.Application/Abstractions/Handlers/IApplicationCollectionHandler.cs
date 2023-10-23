using MediatR;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.ResultPattern;

namespace ProgrammingInternshipPlatform.Application.Abstractions.Handlers;

public interface
    IApplicationCollectionHandler<in TRequest, TPayload, TFailure> : IRequestHandler<TRequest,
        HandlerResult<IReadOnlyList<TPayload>, TFailure>>
    where TRequest : IApplicationCollectionRequest<TPayload, TFailure>
{
}