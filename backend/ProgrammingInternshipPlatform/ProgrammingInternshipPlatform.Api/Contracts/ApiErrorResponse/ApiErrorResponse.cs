using System.Net;

namespace ProgrammingInternshipPlatform.Api.Contracts.ApiErrorResponse;

public class ApiErrorResponse
{
    private readonly List<string> _errorMessages = new();
    public HttpStatusCode StatusCode { get; set; }
    public IReadOnlyCollection<string> ErrorMessages => _errorMessages;
    public DateTime Timestamp { get; } = DateTime.UtcNow;

    public void AddErrorMessage(string errorMessage)
    {
        _errorMessages.Add(errorMessage);
    }
}