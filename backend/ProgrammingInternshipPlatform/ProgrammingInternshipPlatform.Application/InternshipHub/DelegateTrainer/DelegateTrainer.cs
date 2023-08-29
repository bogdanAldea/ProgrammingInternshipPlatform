using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Application.Abstractions.Handlers;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.Accounts.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Enums;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Models;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Trainers.Models;
using ProgrammingInternshipPlatform.Domain.Shared.ErrorHandling.Exceptions;

namespace ProgrammingInternshipPlatform.Application.InternshipHub.DelegateTrainer;

public record DelegateTrainerCommand(Guid InternshipId, Guid AccountId,
    IReadOnlyCollection<TechnologyStack> Technologies) : IApplicationRequest<Internship>;

public class DelegateTrainerHandler : IApplicationHandler<DelegateTrainerCommand, Internship>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public DelegateTrainerHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }

    public async Task<HandlerResult<Internship>> Handle(DelegateTrainerCommand request,
        CancellationToken cancellationToken)
    {
        var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        var accountId = new AccountId(request.AccountId);
        var internshipToAddTrainerTo = await _context.Internships
            .Where(internship => internship.Id.Value == request.InternshipId)
            .SingleOrDefaultAsync(cancellationToken);

        if (internshipToAddTrainerTo is null)
        {
            return HandlerResultFailureHelper.NotFoundFailure<Internship>(FailureMessages.Internship
                .InternshipNotFound);
        }

        try
        {
            try
            {
                var assignedTrainer = await Trainer.AssignMemberAsTrainer(accountId: accountId, 
                    technologies: request.Technologies, cancellationToken);
                await internshipToAddTrainerTo.DelegateTrainer(assignedTrainer);
                await _context.SaveChangesAsync(cancellationToken);
                return HandlerResult<Internship>.Success();
            }
            catch (DomainModelValidationException exception)
            {

                return exception.DomainValidationFailure is not null
                    ? HandlerResultFailureHelper.DomainValidationFailure<Internship>(exception.DomainValidationFailure)
                    : HandlerResultFailureHelper.DomainValidationFailure<Internship>(exception.Message);
            }
        }
        catch (Exception exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            return HandlerResultFailureHelper.TransactionFailure<Internship>(exception.Message);
        }
    }
}