﻿using ProgrammingInternshipPlatform.Domain.Shared.Validators;

namespace ProgrammingInternshipPlatform.Application.ResultPattern;

public class HandlerResultFailureHelper
{
    private HandlerResultFailureHelper(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }
    public string ErrorMessage { get; }

    public static HandlerResult<TResponse> NotFoundFailure<TResponse>(string message)
    {
        var applicationError = FailureReason.NotFoundFailure(message);
        return HandlerResult<TResponse>.Fail(applicationError);
    }
    
    public static HandlerResult<TResponse> InternalServerFailure<TResponse>(string message)
    {
        var applicationError = FailureReason.NotFoundFailure(message);
        return HandlerResult<TResponse>.Fail(applicationError);
    }
    
    public static HandlerResult<TResponse> TransactionFailure<TResponse>(string message)
    {
        var applicationError = FailureReason.TransactionFailure(message);
        return HandlerResult<TResponse>.Fail(applicationError);
    }
    
    public static HandlerResult<TResponse> DomainValidationFailure<TResponse>(DomainValidationFailure failure)
    {
        var applicationError = FailureReason.DomainValidationFailure(failure);
        return HandlerResult<TResponse>.Fail(applicationError);
    }
}