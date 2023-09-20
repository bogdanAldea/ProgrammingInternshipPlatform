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
using ProgrammingInternshipPlatform.Domain.InternshipHub.Mentorships.Models;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Trainers.Models;

namespace ProgrammingInternshipPlatform.Application.InternshipHub.Mentorships.GetAllMentorshipPairs;

public record GetAllMentorshipPairsQuery(InternshipId InternshipId) : IApplicationCollectionRequest<MentorshipResponse>;

public class
    GetAllMentorshipPairsHandler : IApplicationCollectionHandler<GetAllMentorshipPairsQuery, MentorshipResponse>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;
    private readonly IAccountsService _accountsService;
    private readonly IOptions<RoleSettings> _roleSettings;

    public GetAllMentorshipPairsHandler(
        ProgrammingInternshipPlatformDbContext context,
        IAccountsService accountsService,
        IOptions<RoleSettings> roleSettings)
    {
        _context = context;
        _accountsService = accountsService;
        _roleSettings = roleSettings;
    }

    public async Task<HandlerResult<IReadOnlyList<MentorshipResponse>>> Handle(GetAllMentorshipPairsQuery request,
        CancellationToken cancellationToken)
    {
        var internship = await GetInternship(request.InternshipId, cancellationToken);

        if (internship is null)
        {
            return HandlerResultFailureHelper.NotFoundFailure<IReadOnlyList<MentorshipResponse>>(
                FailureMessages.Internship.InternshipNotFound);
        }

        var mentorshipPairs = new List<MentorshipResponse>();

        try
        {
            var trainerAccounts = await GetAllTrainers();
            var internAccounts = await GetAllInterns();

            foreach (var mentorship in internship.Mentorships)
            {
                var trainer = FindTrainerFromInternshipInvolvedInMentorship(internship, mentorship);
                var intern = FindInternFromInternshipInvolvedInMentorship(internship, mentorship);

                if (trainer is null || intern is null)
                {
                    return HandlerResultFailureHelper.NotFoundFailure<IReadOnlyList<MentorshipResponse>>(FailureMessages.Internship.TrainerOrInternNotFound);
                }

                var trainerAccount = trainerAccounts.SingleOrDefault(account => account.Id.Value == trainer.AccountId.Value);
                var internAccount = internAccounts.SingleOrDefault(account => account.Id.Value == intern.AccountId.Value);

                if (trainerAccount is null || internAccount is null)
                {
                    return HandlerResultFailureHelper.NotFoundFailure<IReadOnlyList<MentorshipResponse>>(FailureMessages.Account.TrainerOrInternAccountNotFound);
                }

                var mentorshipsPair = 
                    CreateMentorshipPairResponse(trainerAccount, internAccount, mentorship.Id.Value);

                mentorshipPairs.Add(mentorshipsPair);
            }
        
            return HandlerResult<IReadOnlyList<MentorshipResponse>>.Success(mentorshipPairs);
        }
        catch (NullReferenceException)
        {
            return HandlerResultFailureHelper.InternalServerFailure<IReadOnlyList<MentorshipResponse>>("");
        }
    }

    private async Task<Internship?> GetInternship(InternshipId internshipId, CancellationToken cancellationToken)
        => await _context.Internships
            .Include(internship => internship.Interns)
            .Include(internship => internship.Trainers)
            .Include(internship => internship.Mentorships)
            .Where(internship => internship.Id == internshipId)
            .SingleOrDefaultAsync(cancellationToken);

    private async Task<IReadOnlyList<Account>> GetAllTrainers()
    {
        if (_roleSettings.Value.TrainerRoleId is null)
        {
            throw new NullReferenceException();
        }
        var allTrainers = await _accountsService.GetAccountsByRole(_roleSettings.Value.TrainerRoleId);
        return allTrainers.ToList();
    }

    private async Task<IReadOnlyList<Account>> GetAllInterns()
    {
        if (_roleSettings.Value.InternRoleId is null)
        {
            throw new NullReferenceException();
        }
        var allInterns = await _accountsService.GetAccountsByRole(_roleSettings.Value.InternRoleId);
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
}