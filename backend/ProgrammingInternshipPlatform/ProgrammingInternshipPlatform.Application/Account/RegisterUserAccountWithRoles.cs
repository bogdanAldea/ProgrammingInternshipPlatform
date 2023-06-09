﻿using System.Collections.ObjectModel;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.Account.UserAccounts;
using ProgrammingInternshipPlatform.Domain.Organisation.Companies;
using ProgrammingInternshipPlatform.Domain.Shared.ErrorHandling.Exceptions;

namespace ProgrammingInternshipPlatform.Application.Account;

public record RegisterUserAccountWithRolesCommand(string FirstName, string LastName, string Email, string Password,
    string? PictureUrl, Guid? CompanyId, IReadOnlyList<string> Roles) : IRequest<HandlerResult<UserAccount>>;

public class
    RegisterUserAccountWithRolesHandler : IRequestHandler<RegisterUserAccountWithRolesCommand,
        HandlerResult<UserAccount>>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public RegisterUserAccountWithRolesHandler(ProgrammingInternshipPlatformDbContext context,
        UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<HandlerResult<UserAccount>> Handle(RegisterUserAccountWithRolesCommand request,
        CancellationToken cancellationToken)
    {
        var identityAlreadyExists = await CheckIfEmailIsAlreadyRegistered(request.Email, cancellationToken);

        if (identityAlreadyExists)
        {
            return HandleEMailAlreadyRegisteredError();
        }

        List<IdentityRole> validatedRoles = new();
        foreach (var roleId in request.Roles)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role is null)
            {
                return HandleRoleNotFoundError();
            }

            validatedRoles.Add(role);
        }
        
        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var newIdentity = new IdentityUser { Email = request.Email, UserName = request.Email};
            var createdIdentity = await _userManager.CreateAsync(newIdentity, request.Password);
            if (!createdIdentity.Succeeded)
            {
                return await HandleIdentityCreationError(createdIdentity, transaction, cancellationToken);
            }

            var roleAssignResult = await AddRolesToIdentity(newIdentity, validatedRoles);
            if (!roleAssignResult.Succeeded)
            {
                return await HandleIdentityCreationError(createdIdentity, transaction, cancellationToken);
            }

            try
            {
                return await CreateUserAccountForIdentity(request, newIdentity, cancellationToken, transaction);
            }
            catch (DomainModelValidationException exception)
            {
                return await HandleUserAccountCreationError(transaction, exception.Message, cancellationToken);
            }
        }
        catch (Exception exception)
        {
            return await HandleTransactionError(transaction, exception.Message, cancellationToken);
        }
    }

    private async Task<bool> CheckIfEmailIsAlreadyRegistered(string email, CancellationToken cancellationToken)
    {
        return await _userManager.Users.AnyAsync(user => user.Email == email, cancellationToken);
    }

    private HandlerResult<UserAccount> HandleEMailAlreadyRegisteredError()
    {
        var emailAlreadyRegisteredError =
            ApplicationError.IdentityUserAlreadyExists(ApplicationErrorMessages.UserAccount.EmailAlreadyRegistered);
        return HandlerResult<UserAccount>.Fail(emailAlreadyRegisteredError);
    }

    private HandlerResult<UserAccount> HandleRoleNotFoundError()
    {
        var roleNotFoundError =
            ApplicationError.NotFoundFailure(ApplicationErrorMessages.UserAccount.RoleNotFound);
        return HandlerResult<UserAccount>.Fail(roleNotFoundError);
    }

    private async Task<IdentityResult> AddRolesToIdentity(IdentityUser newIdentity,
        IReadOnlyList<IdentityRole> validatedRoles)
    {
        var roleNames = validatedRoles.Select(role => role.Name);
        return await _userManager.AddToRolesAsync(newIdentity, roleNames);
    }

    private async Task<HandlerResult<UserAccount>> HandleIdentityCreationError(IdentityResult identityResult,
        IDbContextTransaction transaction, CancellationToken cancellationToken)
    {
        var identityErrorMessages = new List<string>();
        identityResult.Errors.ToList().ForEach(error
            => identityErrorMessages.Add(error.Description));

        var identityRegistrationError = ApplicationError.AddErrors(
            ApplicationErrorType.IdentityRegistrationFailure, identityErrorMessages);

        await transaction.RollbackAsync(cancellationToken);

        return HandlerResult<UserAccount>.Fail(identityRegistrationError);
    }

    private async Task<HandlerResult<UserAccount>> CreateUserAccountForIdentity(
        RegisterUserAccountWithRolesCommand request,
        IdentityUser newIdentity, CancellationToken cancellationToken, IDbContextTransaction transaction)
    {
        // This should be a factory pattern
        UserAccount newUserAccount;
        if(request.CompanyId is null) {
            newUserAccount = await UserAccount.CreateNew(
                firstName: request.FirstName,
                lastName: request.LastName,
                pictureUrl: request.PictureUrl,
                identityId: Guid.Parse(newIdentity.Id),
                cancellationToken
            );
        }
        else
        {
            newUserAccount = await UserAccount.CreateNew(
                firstName: request.FirstName,
                lastName: request.LastName,
                identityId: Guid.Parse(newIdentity.Id),
                companyId: new CompanyId((Guid)request.CompanyId),
                cancellationToken);
        }

        var createdUserAccount = await _context.UserAccount.AddAsync(newUserAccount, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
        return HandlerResult<UserAccount>.Success(createdUserAccount.Entity);
    }

    private async Task<HandlerResult<UserAccount>> HandleUserAccountCreationError(IDbContextTransaction transaction,
        string errorMessage, CancellationToken cancellationToken)
    {
        await transaction.RollbackAsync(cancellationToken);
        var userAccountValidationError =
            ApplicationError.DomainValidationFailure(errorMessage);
        return HandlerResult<UserAccount>.Fail(userAccountValidationError);
    }

    private async Task<HandlerResult<UserAccount>> HandleTransactionError(IDbContextTransaction transaction,
        string errorMessage, CancellationToken cancellationToken)
    {
        await transaction.RollbackAsync(cancellationToken);
        var transactionApplicationError = ApplicationError.IdentityRegistrationFailure(errorMessage);
        return HandlerResult<UserAccount>.Fail(transactionApplicationError);
    }
}