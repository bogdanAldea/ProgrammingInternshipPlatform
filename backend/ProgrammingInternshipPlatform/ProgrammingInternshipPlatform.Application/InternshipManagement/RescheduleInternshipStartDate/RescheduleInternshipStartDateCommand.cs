using MediatR;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Models;

namespace ProgrammingInternshipPlatform.Application.InternshipManagement.RescheduleInternshipStartDate;

public class RescheduleInternshipStartDateCommand : IRequest<HandlerResult<Internship>>
{
    public RescheduleInternshipStartDateCommand(InternshipId internshipId, DateTime rescheduledStartDate)
    {
        InternshipId = internshipId;
        RescheduledStartDate = rescheduledStartDate;
    }
    
    public InternshipId InternshipId { get; }
    public DateTime RescheduledStartDate { get; }
}