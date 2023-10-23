using MediatR;
using ProgrammingInternshipPlatform.Application.ResultPattern;

namespace ProgrammingInternshipPlatform.Application.Abstractions.Requests;

public interface IApplicationRequest<TPayload, TFailure> :  IRequest<HandlerResult<TPayload, TFailure>> { }