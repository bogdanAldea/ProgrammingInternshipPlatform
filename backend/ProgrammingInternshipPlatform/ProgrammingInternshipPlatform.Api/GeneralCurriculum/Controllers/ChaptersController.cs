using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgrammingInternshipPlatform.Api.API.Constants;
using ProgrammingInternshipPlatform.Api.API.Controllers;
using ProgrammingInternshipPlatform.Api.GeneralCurriculum.Contracts.Requests;
using ProgrammingInternshipPlatform.Api.GeneralCurriculum.Contracts.Responses;
using ProgrammingInternshipPlatform.Application.GeneralCurriculum.Chapters;
using ProgrammingInternshipPlatform.Application.GeneralCurriculum.Contracts.Responses;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Identifiers;

namespace ProgrammingInternshipPlatform.Api.GeneralCurriculum.Controllers;

public class ChaptersController : ApiController
{
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllChapters()
    {
        var allChaptersQuery = new GetAllChaptersQuery();
        var queryResult = await Mediator.Send(allChaptersQuery);
        if (queryResult.IsSuccess && queryResult.Payload is not null)
        {
            var mappedChapters = 
                queryResult.Payload.Select(ChapterWithVersionServerResponse.CreateFromResource);
            return Ok(mappedChapters);
        }
        return HandleApiErrorResponse(queryResult.FailureReason);
    }

    [HttpGet]
    [Authorize]
    [Route(ApiRoutes.IdRoute)]
    public async Task<IActionResult> GetUnversionedChapter(Guid id)
    {
        var unversionedChapterQuery = new GetUnversionedChapterQuery(new ChapterId(id));
        var queryResult = await Mediator.Send(unversionedChapterQuery);
        if (queryResult.IsSuccess && queryResult.Payload is not null)
        {
            var mappedChapter = ChapterWithLessonsWithVersionsServerResponse.CreateFromResource(queryResult.Payload);
            return Ok(mappedChapter);
        }
        return HandleApiErrorResponse(queryResult.FailureReason);
    }

    [HttpGet]
    [Authorize]
    [Route(ApiRoutes.ChapterRoutes.Lessons)]
    public async Task<IActionResult> GetLessonsFromUnversionedChapter(Guid id)
    {
        var allLessonsFromUnversionedChapterQuery = new GetLessonsFromUnversionedChapterQuery(new ChapterId(id));
        var queryResult = await Mediator.Send(allLessonsFromUnversionedChapterQuery);
        if (queryResult.IsSuccess && queryResult.Payload is not null)
        {
            var mappedLessons = queryResult.Payload.Select(LessonServerResponse.CreateFromResource);
            return Ok(mappedLessons);
        }

        return HandleApiErrorResponse(queryResult.FailureReason);
    }

    [HttpPost]
    [Authorize]
    [Route(ApiRoutes.ChapterRoutes.Version)]
    public async Task<IActionResult> CreateVersionOfChapter(Guid id)
    {
        var versionChapterCommand = new CreateVersionedOfChapterCommand(new ChapterId(id));
        var commandResult = await Mediator.Send(versionChapterCommand);
        if (commandResult.IsSuccess)
        {
            return Ok();
        }
        return HandleApiErrorResponse(commandResult.FailureReason);
    }

    [HttpPatch]
    [Authorize]
    [Route(ApiRoutes.ChapterRoutes.Lessons)]
    public async Task<IActionResult> AddLessonToNotVersionedChapter(Guid id, [FromBody] NewLessonRequest request)
    {
        var newLessonCommand = new AddNewLessonToNotVersionedChapterCommand(
            ChapterId: new ChapterId(request.ChapterId),
            Title: request.Title,
            Description: request.Description,
            LearningObjective: request.LearningObjective
        );

        var commandResult = await Mediator.Send(newLessonCommand);
        if (commandResult is null)
            return NoContent();
        return HandleApiErrorResponse(commandResult.FailureReason);
    }
}