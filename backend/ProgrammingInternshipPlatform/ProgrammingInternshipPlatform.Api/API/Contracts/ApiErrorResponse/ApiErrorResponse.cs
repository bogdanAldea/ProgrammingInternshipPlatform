using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace ProgrammingInternshipPlatform.Api.API.Contracts.ApiErrorResponse;

public class ApiErrorResponse<TFailure>
{
    private readonly List<TFailure?> _errorMessages = new();
    public HttpStatusCode StatusCode { get; set; }
    public IReadOnlyCollection<TFailure?> ErrorMessages => _errorMessages;
    public DateTime Timestamp { get; } = DateTime.UtcNow;

    public void AddErrorMessage(TFailure? errorMessage)
    {
        _errorMessages.Add(errorMessage);
    }
    
    public void AddErrorMessage(string errorMessage)
    {
        _errorMessages.Add((TFailure)(object)errorMessage);
    }

    public static IActionResult CreateErrorResponse(ActionContext context)
    {
        var apiErrorResponse = new ApiErrorResponse<TFailure> { StatusCode = HttpStatusCode.BadRequest };
        foreach (var error in context.ModelState)
        {
            foreach (var innerError in error.Value.Errors)
            {
                apiErrorResponse.AddErrorMessage(innerError.ErrorMessage);
            }
        }

        return new BadRequestObjectResult(apiErrorResponse);
    }
}