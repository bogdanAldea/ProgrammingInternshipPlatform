using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace ProgrammingInternshipPlatform.Api.Contracts.ApiErrorResponse;

public class ApiErrorResponse
{
    private readonly List<string?> _errorMessages = new();
    public HttpStatusCode StatusCode { get; set; }
    public IReadOnlyCollection<string?> ErrorMessages => _errorMessages;
    public DateTime Timestamp { get; } = DateTime.UtcNow;

    public void AddErrorMessage(string? errorMessage)
    {
        _errorMessages.Add(errorMessage);
    }

    public static IActionResult CreateErrorResponse(ActionContext context)
    {
        var apiErrorResponse = new ApiErrorResponse();
        apiErrorResponse.StatusCode = HttpStatusCode.BadRequest;
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