using MediatR;
using ProgrammingInternshipPlatform.Application.ResultPattern;

namespace ProgrammingInternshipPlatform.Application.Abstractions.Requests;

public interface IApplicationRequest<TResponse> :  IRequest<HandlerResult<TResponse>> { }