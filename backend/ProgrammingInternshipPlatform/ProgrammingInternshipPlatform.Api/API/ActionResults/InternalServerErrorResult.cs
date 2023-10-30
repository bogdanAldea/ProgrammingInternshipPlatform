using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ProgrammingInternshipPlatform.Api.API.ActionResults;

public class InternalServerErrorResult : ObjectResult
{
    private const int DefaultStatusCode = StatusCodes.Status500InternalServerError;
    
    public InternalServerErrorResult([ActionResultObjectValue] object? error)
        : base(error)
    {
        StatusCode = DefaultStatusCode;
    }
}