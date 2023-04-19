using MediatR;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Models;

namespace ProgrammingInternshipPlatform.Application.InternshipManagement.GetInternshipProgramById;

public class GetInternshipProgramByIdQuery : IRequest<HandlerResult<Internship>>
{
    public GetInternshipProgramByIdQuery(InternshipId id)
    {
        Id = id;
    }
    public InternshipId Id { get; }
}