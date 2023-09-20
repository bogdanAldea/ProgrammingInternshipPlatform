using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProgrammingInternshipPlatform.Application.Abstractions.GraphApi;
using ProgrammingInternshipPlatform.Application.Abstractions.GraphApi.Responses;
using ProgrammingInternshipPlatform.Application.Abstractions.GraphApi.Settings;
using ProgrammingInternshipPlatform.Application.Abstractions.Handlers;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.InternshipHub.Responses;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Interns.Models;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Models;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Mentorships.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Mentorships.Models;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Trainers.Models;

namespace ProgrammingInternshipPlatform.Application.InternshipHub.Mentorships.GetMentorshipPair;

public record GetMentorshipPairQuery
    (InternshipId InternshipId, MentorshipId MentorshipId) : IApplicationRequest<MentorshipResponse>;

public class GetMentorshipPairHandler : IApplicationHandler<GetMentorshipPairQuery, MentorshipResponse>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;
    private readonly IAccountsService _accountsService;
    private readonly IOptions<RoleSettings> _roleOptions;

    public GetMentorshipPairHandler(ProgrammingInternshipPlatformDbContext context, IAccountsService accountsService,
        IOptions<RoleSettings> roleOptions)
    {
        _context = context;
        _accountsService = accountsService;
        _roleOptions = roleOptions;
    }

    public async Task<HandlerResult<MentorshipResponse>> Handle(GetMentorshipPairQuery request,
        CancellationToken cancellationToken)
    {
        var internship = await _context.Internships
            .Include(internship => internship.Trainers)
            .Include(internship => internship.Interns)
            .Include(internship => internship.Mentorships)
            .Where(internship => internship.Id == request.InternshipId)
            .SingleOrDefaultAsync(cancellationToken);

        if (internship is null)
            return HandlerResultFailureHelper.NotFoundFailure<MentorshipResponse>(FailureMessages.Internship
                .InternshipNotFound);

        var mentorship = internship.Mentorships
            .SingleOrDefault(mentorship => mentorship.Id == request.MentorshipId);

        if (mentorship is null)
            return HandlerResultFailureHelper.NotFoundFailure<MentorshipResponse>(FailureMessages.Internship
                .MentorshipProgramNotFound);

        try
        {
            var trainerAccounts = await GetAllTrainers();
            var internAccounts = await GetAllInterns();

            var trainer = FindTrainerFromInternshipInvolvedInMentorship(internship, mentorship);
            var intern = FindInternFromInternshipInvolvedInMentorship(internship, mentorship);

            if (trainer is null || intern is null)
            {
                return HandlerResultFailureHelper.NotFoundFailure<MentorshipResponse>(FailureMessages.Internship
                    .TrainerOrInternNotFound);
            }

            var trainerAccount = MatchMentorshipMemberWithAccount(trainerAccounts, trainer.AccountId.Value);
            var internAccount = MatchMentorshipMemberWithAccount(internAccounts, intern.AccountId.Value);
            
            if (trainerAccount is null || internAccount is null)
            {
                return HandlerResultFailureHelper.NotFoundFailure<MentorshipResponse>(
                    FailureMessages.Account.TrainerOrInternAccountNotFound);
            }
            
            var mentorshipPair = CreateMentorshipPairResponse(
                trainerAccount, internAccount, mentorship.Id.Value);
            
            return HandlerResult<MentorshipResponse>.Success(mentorshipPair);
        }
        catch (NullReferenceException)
        {
            return HandlerResultFailureHelper.InternalServerFailure<MentorshipResponse>("");
        }
        
    }

    private async Task<IReadOnlyList<Account>> GetAllTrainers()
    {
        if (_roleOptions.Value.TrainerRoleId is null)
        {
            throw new NullReferenceException();
        }

        var allTrainers = await _accountsService.GetAccountsByRole(_roleOptions.Value.TrainerRoleId);
        return allTrainers.ToList();
    }

    private async Task<IReadOnlyList<Account>> GetAllInterns()
    {
        if (_roleOptions.Value.InternRoleId is null)
        {
            throw new NullReferenceException();
        }

        var allInterns = await _accountsService.GetAccountsByRole(_roleOptions.Value.InternRoleId);
        return allInterns.ToList();
    }

    private Trainer? FindTrainerFromInternshipInvolvedInMentorship(Internship internship, Mentorship mentorship)
    {
        return internship.Trainers.SingleOrDefault(trainer => trainer.Id == mentorship.TrainerId);
    }

    private Intern? FindInternFromInternshipInvolvedInMentorship(Internship internship, Mentorship mentorship)
    {
        return internship.Interns.SingleOrDefault(intern => intern.InternId == mentorship.InternId);
    }
    
    private MentorshipResponse CreateMentorshipPairResponse(Account trainer, Account intern, Guid mentorshipId)
    {
        return new MentorshipResponse
        {
            Trainer = trainer,
            Intern = intern,
            MentorshipId = mentorshipId
        };
    }

    private Account? MatchMentorshipMemberWithAccount(IReadOnlyList<Account> accounts, Guid trainerAccountId)
    {
        return accounts.SingleOrDefault(account => account.Id.Value == trainerAccountId);
    }
}