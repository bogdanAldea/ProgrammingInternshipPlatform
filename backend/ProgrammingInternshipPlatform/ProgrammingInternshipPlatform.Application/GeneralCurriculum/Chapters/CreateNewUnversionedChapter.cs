using ProgrammingInternshipPlatform.Application.Abstractions.Handlers;
using ProgrammingInternshipPlatform.Application.Abstractions.Requests;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Models;
using ProgrammingInternshipPlatform.Domain.Shared.ErrorHandling.Exceptions;

namespace ProgrammingInternshipPlatform.Application.GeneralCurriculum.Chapters;

public record CreateNewUnversionedChapterCommand(string Title, string Description) : IApplicationRequest<Chapter>;

public class CreateNewUnversionedChapterHandler : IApplicationHandler<CreateNewUnversionedChapterCommand, Chapter>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public CreateNewUnversionedChapterHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }
    
    public async Task<HandlerResult<Chapter>> Handle(CreateNewUnversionedChapterCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var newUnversionedChapter =
                await Chapter.CreateNew(title: request.Title, description: request.Description, cancellationToken);

            var createdUnversionedChapter = await _context.Chapter.AddAsync(newUnversionedChapter, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return HandlerResult<Chapter>.Success(createdUnversionedChapter.Entity);
        }
        catch (DomainModelValidationException exception)
        {
            return HandlerResultFailureHelper.DomainValidationFailure<Chapter>(exception.DomainValidationFailure!);
        }
    }
}