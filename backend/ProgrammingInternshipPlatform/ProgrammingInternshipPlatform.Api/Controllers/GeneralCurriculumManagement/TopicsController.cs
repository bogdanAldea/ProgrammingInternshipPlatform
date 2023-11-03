using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgrammingInternshipPlatform.Api.API.Constants;
using ProgrammingInternshipPlatform.Api.API.Controllers;
using ProgrammingInternshipPlatform.Api.Controllers.Requests;
using ProgrammingInternshipPlatform.Application.GeneralCurriculumManagement.General;
using ProgrammingInternshipPlatform.Application.GeneralCurriculumManagement.General.CreateGeneralTopic;
using ProgrammingInternshipPlatform.Application.GeneralCurriculumManagement.General.CreateVersionOfTopic;
using ProgrammingInternshipPlatform.Application.GeneralCurriculumManagement.General.GetAllGeneralTopics;
using ProgrammingInternshipPlatform.Application.GeneralCurriculumManagement.General.GetGeneralTopic;
using ProgrammingInternshipPlatform.Application.GeneralCurriculumManagement.Versioned.GetVersionedTopics;
using ProgrammingInternshipPlatform.Application.GeneralCurriculumManagement.ViewTopicReadyForVersioning;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Topics.Models;

namespace ProgrammingInternshipPlatform.Api.Controllers.GeneralCurriculumManagement;

public class TopicsController : ApiController
{
    [HttpGet]
    [Authorize]
    [Route(ApiRoutes.GeneralCurriculum.TopicVersions)]
    public async Task<IActionResult> GetAllVersionsOfTopic(Guid id)
    {
        var allVersionsQuery = new GetAllVersionsOfTopicQuery(new TopicId(id));
        var queryResult = await Mediator.Send(allVersionsQuery);
        return HandleApiResponse(queryResult);
    }
    
    [HttpGet]
    [Authorize]
    [Route(ApiRoutes.GeneralCurriculum.TopicReadyToVersion)]
    public async Task<IActionResult> ViewTopicReadyToVersion(Guid id)
    {
        var topicReadyToVersionQuery = new ViewTopicReadyForVersioningQuery(new TopicId(id));
        var queryResult = await Mediator.Send(topicReadyToVersionQuery);
        return HandleApiResponse(queryResult);
    }
    
    [HttpGet]
    [Authorize]
    [Route(ApiRoutes.BaseIdRoute)]
    public async Task<IActionResult> GetGeneralTopic(Guid id)
    {
        var generalTopicQuery = new GetGeneralTopicQuery(new TopicId(id));
        var queryResult = await Mediator.Send(generalTopicQuery);
        return HandleApiResponse(queryResult);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllGeneralTopics()
    {
        var allUnversionedTopicsQuery = new GetAllGeneralTopicsQuery();
        var queryResult = await Mediator.Send(allUnversionedTopicsQuery);
        return HandleApiResponse(queryResult);
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateNewGeneralTopic([FromBody] NewTopicRequest request)
    {
        var createVersionForTopicCommand = new CreateNewGeneralTopicCommand(Title: request.Title, Description: request.Description);
        var commandResult = await Mediator.Send(createVersionForTopicCommand);
        return HandleApiResponse(commandResult, nameof(GetGeneralTopic));
    }

    [HttpPost]
    [Authorize]
    [Route(ApiRoutes.GeneralCurriculum.TopicVersions)]
    public async Task<IActionResult> CreateVersionForTopic(Guid id)
    {
        var createVersionForTopicCommand = new CreateVersionOfTopicCommand(new TopicId(id));
        var commandResult = await Mediator.Send(createVersionForTopicCommand);
        return HandleApiResponse(commandResult, nameof(GetAllVersionsOfTopic));
    }
}