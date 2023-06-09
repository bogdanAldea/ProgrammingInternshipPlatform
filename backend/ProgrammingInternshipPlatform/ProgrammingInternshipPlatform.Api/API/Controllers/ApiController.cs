﻿using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProgrammingInternshipPlatform.Api.API.Contracts.ApiErrorResponse;
using ProgrammingInternshipPlatform.Application.ResultPattern;

namespace ProgrammingInternshipPlatform.Api.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApiController : ControllerBase
{
    private IMediator? _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();

    protected IActionResult HandleApiErrorResponse(ApplicationError applicationError)
    {
        var apiErrorResponse = new ApiErrorResponse();
        if (applicationError.Errors.Count > 0)
        {
            applicationError.Errors
                .ToList()
                .ForEach(error => apiErrorResponse.AddErrorMessage(error));
        }
        else
        {
            apiErrorResponse.AddErrorMessage(applicationError.ApplicationErrorMessage);
        }

        if (applicationError.ApplicationErrorType is ApplicationErrorType.AccessDeniedFailure)
        {
            apiErrorResponse.StatusCode = HttpStatusCode.Forbidden;
            return Forbid();
        }

        if (applicationError.ApplicationErrorType is ApplicationErrorType.ResourceNotFoundFailure)
        {
            apiErrorResponse.StatusCode = HttpStatusCode.NotFound;
            return NotFound(apiErrorResponse);
        }

        apiErrorResponse.StatusCode = HttpStatusCode.BadRequest;
        return BadRequest(apiErrorResponse);
    }
}