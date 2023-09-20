using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgrammingInternshipPlatform.Api.API.Constants;
using ProgrammingInternshipPlatform.Api.API.Controllers;
using ProgrammingInternshipPlatform.Api.InternshipHub.Contracts.Requests;
using ProgrammingInternshipPlatform.Api.InternshipHub.Contracts.Responses;
using ProgrammingInternshipPlatform.Application.Accounts;
using ProgrammingInternshipPlatform.Application.InternshipHub.Internships.CreateInternshipSetup;
using ProgrammingInternshipPlatform.Application.InternshipHub.Internships.GetInternshipPrograms;
using ProgrammingInternshipPlatform.Application.InternshipHub.Internships.GetInternshipSetupConfiguration;
using ProgrammingInternshipPlatform.Application.InternshipHub.Mentorships.GetAllMentorshipPairs;
using ProgrammingInternshipPlatform.Application.InternshipHub.Mentorships.GetMentorshipPair;
using ProgrammingInternshipPlatform.Application.InternshipHub.Responses;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Mentorships.Identifiers;

namespace ProgrammingInternshipPlatform.Api.InternshipHub.Controllers;

public class InternshipsController : ApiController
{
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllInternshipPrograms()
    {
        var allInternshipsQuery = new GetInternshipProgramsQuery();
        var queryResult = await Mediator.Send(allInternshipsQuery);
        if (queryResult.IsSuccess && queryResult.Payload is not null)
        {
            var mappedResults 
                = queryResult.Payload.Select(InternshipWithCoordinatorResponse.MapFrom);
            return Ok(mappedResults);
        }

        return HandleApiErrorResponse(queryResult.FailureReason);
    }

    [HttpGet]
    [Route(ApiRoutes.InternshipRoutes.Setup)]
    [Authorize]
    public async Task<IActionResult> GetInternshipSetup(Guid id)
    {
        var internshipSetupQuery = new GetInternshipSetupConfigurationQuery(id);
        var result = await Mediator.Send(internshipSetupQuery);
        if (result.IsSuccess && result.Payload is not null)
            return Ok(InternshipPartialResponse.MapFrom(result.Payload));
        return HandleApiErrorResponse(result.FailureReason);
    }

    [HttpGet]
    [Authorize]
    [Route(ApiRoutes.InternshipRoutes.Mentorships)]
    public async Task<IActionResult> GetAllMentorshipPairsFromInternship(Guid id)
    {
        var allMentorshipPairsQuery = new GetAllMentorshipPairsQuery(new InternshipId(id));
        var queryResult = await Mediator.Send(allMentorshipPairsQuery);
        if (queryResult.IsSuccess && queryResult.Payload is not null)
        {
            var mappedMentorshipPairs 
                = queryResult.Payload.Select(MentorshipPair.CreateFromResult);
            return Ok(mappedMentorshipPairs);
        }
        return HandleApiErrorResponse(queryResult.FailureReason);
    }

    [HttpGet]
    [Authorize]
    [Route(ApiRoutes.InternshipRoutes.MentorshipPair)]
    public async Task<IActionResult> GetMentorshipPair(Guid id, Guid mentorshipId)
    {
        var mentorshipPairGetQuery = new GetMentorshipPairQuery(new InternshipId(id), new MentorshipId(mentorshipId));
        var queryResult = await Mediator.Send(mentorshipPairGetQuery);
        if (queryResult.IsSuccess && queryResult.Payload is not null)
        {
            var mappedMentorshipPair = MentorshipPair.CreateFromResult(queryResult.Payload);
            return Ok(mappedMentorshipPair);
        }

        return HandleApiErrorResponse(queryResult.FailureReason);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateInternshipSetup([FromBody] InternshipSetupRequest request)
    {
        var internshipSetupCreateCommand = new CreateInternshipSetupCommand(
            Center: request.Center, DurationInMonths: request.DurationInMonths, CoordinatorId: request.CoordinatorId,
            MaxInternsToEnroll: request.MaxInternsToEnroll, ScheduledToStartOn: request.ScheduledToStartOn,
            EstimatedToEndOn: request.EstimatedToEndOn);

        var result = await Mediator.Send(internshipSetupCreateCommand);
        if (result.IsSuccess && result.Payload is not null)
        {
            return Ok(result.Payload.Id);
        }

        return HandleApiErrorResponse(result.FailureReason);
    }
}