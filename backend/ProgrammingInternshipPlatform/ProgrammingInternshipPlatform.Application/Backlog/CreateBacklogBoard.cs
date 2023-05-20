using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.Backlog.Boards;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Interns;
using ProgrammingInternshipPlatform.Domain.ProjectHub.Projects;
using ProgrammingInternshipPlatform.Domain.Shared.Exceptions;

namespace ProgrammingInternshipPlatform.Application.Backlog;

public record CreateBacklogBoardCommand(ProjectId ProjectId, InternId InternId) 
    : IRequest<HandlerResult<Board>>;

public class CreateBacklogBoardHandler : IRequestHandler<CreateBacklogBoardCommand, HandlerResult<Board>>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public CreateBacklogBoardHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }
    
    public async Task<HandlerResult<Board>> Handle(CreateBacklogBoardCommand request, CancellationToken cancellationToken)
    {
        var existingProject = await FindProjectById(request.ProjectId, cancellationToken);

        if (existingProject is null)
        {
            return HandleProjectNotFoundError();
        }
        
        try
        {
            return await HandleCreationForBoard(existingProject, request.InternId, cancellationToken);
        }
        catch (DomainModelValidationException exception)
        {
            return HandleDomainValidationError(exception.Message);
        }
        
    }

    private async Task<Project?> FindProjectById(ProjectId projectId, CancellationToken cancellationToken)
    {
        return await _context.Projects.FirstOrDefaultAsync(project =>
            project.ProjectId == projectId, cancellationToken);
    }

    private HandlerResult<Board> HandleProjectNotFoundError()
    {
        var projectNotFoundError =
            ApplicationError.NotFoundFailure(ApplicationErrorMessages.Project.ProjectNotFound);
        return HandlerResult<Board>.Fail(projectNotFoundError);
    }

    private async Task<HandlerResult<Board>> HandleCreationForBoard(Project project, InternId ownerIntern, CancellationToken cancellationToken)
    {
        var newBoardForProject = await Board.CreateNew(project.ProjectId, ownerIntern,
            project.Title, cancellationToken);
        var createdBoardForProject = await _context.Boards.AddAsync(newBoardForProject, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return HandlerResult<Board>.Success(createdBoardForProject.Entity);
    }

    private HandlerResult<Board> HandleDomainValidationError(string errorMessage)
    {
        var domainValidationError = ApplicationError.DomainValidationFailure(errorMessage);
        return HandlerResult<Board>.Fail(domainValidationError);
    }
}