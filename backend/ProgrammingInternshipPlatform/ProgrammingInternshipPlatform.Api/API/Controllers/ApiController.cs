using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProgrammingInternshipPlatform.Api.API.ActionResults;
using ProgrammingInternshipPlatform.Api.API.Contracts.ApiErrorResponse;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Application.ResultPattern.FailureReason;
using ProgrammingInternshipPlatform.Application.ResultPattern.SuccessResult;

namespace ProgrammingInternshipPlatform.Api.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApiController : ControllerBase
{
    private IMediator? _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
    
    protected IActionResult HandleApiResponse<TPayload, TFailure>(HandlerResult<TPayload, TFailure> operationResult, string? createdAtActionName = null)
    {
        return operationResult.IsSuccess
            ? HandleApiSuccessResponse(operationResult.SuccessResultWithPayload!, createdAtActionName)
            : HandleApiErrorResponse(operationResult.FailureReason!);
    }

    protected IActionResult HandleApiErrorResponse<TFailure>(FailureReason<TFailure> failureReason)
    {
        var apiErrorResponse = new ApiErrorResponse<TFailure>();
        if (failureReason.Failures.Count > 0)
        {
            failureReason.Failures
                .ToList()
                .ForEach(failure => apiErrorResponse.AddErrorMessage(failure));
        }
        else
        {
            apiErrorResponse.AddErrorMessage(failureReason.Failure);
        }

        return CreateErrorResponse(apiErrorResponse, failureReason);
    }

    protected IActionResult HandleApiSuccessResponse<TPayload>(SuccessResult<TPayload> successResult, string? createActionName)
    {
        switch (successResult.SuccessType)
        {
            case SuccessType.WithPayload:
                return CreateSuccessResponseWithPayload(successResult, createActionName);
            case SuccessType.WithoutPayload:
                return CreateSuccessResponseWithoutPayload(successResult);
            default:
                throw new ArgumentNullException();
        }
    }
    
    private IActionResult CreateSuccessResponseWithPayload<TPayload>(SuccessResult<TPayload> successResult,
        string? createActionName)
    {
        switch (successResult.OperationType)
        {
            case OperationType.Read:
                return Ok(successResult.Payload);
            case OperationType.Create:
                return CreatedAtAction(createActionName, new { Id = successResult.Payload });
            case OperationType.UpdateWithPayload:
                return Ok(successResult.Payload);
            default:
                throw new ArgumentNullException();
        }
    }
    
    private IActionResult CreateSuccessResponseWithoutPayload(SuccessResult successResult)
    {
        switch (successResult.OperationType)
        {
            case OperationType.Update:
                return Ok();
            default:
                throw new ArgumentNullException();
        }
    }

    private IActionResult CreateErrorResponse<TFailure>(ApiErrorResponse<TFailure> apiErrorResponse, FailureReason<TFailure> failureReason)
    {
        switch (failureReason.FailureType)
        {
            case FailureType.ResourceNotFoundFailure:
                apiErrorResponse.StatusCode = HttpStatusCode.NotFound;
                return NotFound(apiErrorResponse);
            case FailureType.DomainValidationFailure:
                apiErrorResponse.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(apiErrorResponse);
            /*case FailureType.InternalServerFailure:
                apiErrorResponse.StatusCode = HttpStatusCode.InternalServerError;
                return InternalServerError(apiErrorResponse);*/
            default:
                throw new ArgumentNullException();
        }
    }

    /*public IActionResult InternalServerError(object? value)
        => new InternalServerErrorResult(value);*/
}