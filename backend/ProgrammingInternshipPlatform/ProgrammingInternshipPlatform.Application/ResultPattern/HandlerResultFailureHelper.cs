using ProgrammingInternshipPlatform.Domain.Shared.Validators;

namespace ProgrammingInternshipPlatform.Application.ResultPattern;

public class HandlerResultFailureHelper
{
    private HandlerResultFailureHelper(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }
    public string ErrorMessage { get; }
    
}