using MediatR;
using ProgrammingInternshipPlatform.Application.ResultPattern;

namespace ProgrammingInternshipPlatform.Application.Abstractions.Requests;

public interface IApplicationCollectionRequest<TPayload, TFailure> : IRequest<HandlerResult<IReadOnlyList<TPayload>, TFailure>> { }