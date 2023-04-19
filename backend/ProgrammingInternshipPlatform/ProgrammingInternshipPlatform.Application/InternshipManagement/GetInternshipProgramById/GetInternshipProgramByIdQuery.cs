using MediatR;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Domain.Internships.Identifiers;
using ProgrammingInternshipPlatform.Domain.Internships.Models;

namespace ProgrammingInternshipPlatform.Application.InternshipManagement.GetInternshipProgramById;

public class GetInternshipProgramByIdQuery : IRequest<HandlerResult<Internship>>
{
    public GetInternshipProgramByIdQuery(InternshipId id)
    {
        Id = id;
    }
    public InternshipId Id { get; }
}