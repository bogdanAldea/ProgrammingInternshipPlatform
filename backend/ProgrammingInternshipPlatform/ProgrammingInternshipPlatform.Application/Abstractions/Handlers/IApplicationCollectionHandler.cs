using MediatR;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.ResultPattern;

namespace ProgrammingInternshipPlatform.Application.Abstractions.Handlers;

public interface IApplicationCollectionHandler<in TRequest, TResponse> : IRequestHandler<TRequest, HandlerResult<IReadOnlyList<TResponse>>>
    where TRequest : IApplicationCollectionRequest<TResponse> { }    