﻿using MediatR;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.ResultPattern;

namespace ProgrammingInternshipPlatform.Application.Abstractions.Handlers;

public interface
    IApplicationHandler<in TRequest, TPayload, TFailure> : IRequestHandler<TRequest, HandlerResult<TPayload, TFailure>>
    where TRequest : IApplicationRequest<TPayload, TFailure>
{
}