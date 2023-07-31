using MediatR;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.ResultPattern;

namespace ProgrammingInternshipPlatform.Application.Abstractions.Handlers;

public interface IApplicationCollectionHandler<in TRequest, TResponse> : IRequestHandler<TRequest, HandlerResult<List<TResponse>>>
    where TRequest : IApplicationCollectionRequest<TResponse> { }    