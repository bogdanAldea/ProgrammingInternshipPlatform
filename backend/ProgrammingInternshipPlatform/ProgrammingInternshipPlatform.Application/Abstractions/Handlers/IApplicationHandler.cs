using MediatR;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.ResultPattern;

namespace ProgrammingInternshipPlatform.Application.Abstractions.Handlers;

public interface IApplicationHandler<in TRequest, TResponse> : IRequestHandler<TRequest, HandlerResult<TResponse>>
    where TRequest : IApplicationRequest<TResponse> { }