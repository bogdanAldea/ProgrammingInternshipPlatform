using MediatR;
using ProgrammingInternshipPlatform.Application.ResultPattern;

namespace ProgrammingInternshipPlatform.Application.Abstractions.Requests;

public interface IApplicationCollectionRequest<TResponse> : IRequest<HandlerResult<IReadOnlyList<TResponse>>> { }