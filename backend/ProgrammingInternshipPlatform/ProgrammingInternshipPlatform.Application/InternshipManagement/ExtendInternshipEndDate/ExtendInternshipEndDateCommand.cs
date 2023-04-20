using MediatR;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Models;

namespace ProgrammingInternshipPlatform.Application.InternshipManagement.ExtendInternshipEndDate;

public class ExtendInternshipEndDateCommand : IRequest<HandlerResult<Internship>>
{
    public ExtendInternshipEndDateCommand(InternshipId internshipId, DateTime extendedEndDate)
    {
        InternshipId = internshipId;
        ExtendedEndDate = extendedEndDate;
    }
    public InternshipId InternshipId { get; }
    public DateTime ExtendedEndDate { get; }
}