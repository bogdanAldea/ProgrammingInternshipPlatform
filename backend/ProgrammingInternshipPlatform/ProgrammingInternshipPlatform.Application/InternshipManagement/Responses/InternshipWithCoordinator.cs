using ProgrammingInternshipPlatform.Application.Abstractions.GraphApi.Responses;
using ProgrammingInternshipPlatform.Application.Helpers.EnumRetrieval;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships.Enums;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships.Models;

namespace ProgrammingInternshipPlatform.Application.InternshipManagement.Responses;

public class InternshipWithCoordinator
{
    public Guid InternshipId { get; private set; }
    public Guid CoordinatorId { get; private set; }
    public string CoordinatorName { get; private set; } = null!;
    public string CoordinatorEmail { get; private set; } = null!;
    public int DurationInMonths { get; private set; }
    public int MaxEnrolledInterns { get; private set; }
    public DateTime ScheduledToStartDate { get; private set; }
    public DateTime? EstimatedGraduationDate { get; private set; }
    public Converted<InternshipStatus> InternshipStatus { get; private set; } = null!;

    public static InternshipWithCoordinator CreateFromResult(Internship internship, Account account)
    {
        return new InternshipWithCoordinator
        {
            InternshipId = internship.InternshipId.Value,
            CoordinatorId = account.Id.Value,
            CoordinatorName = account.DisplayName,
            CoordinatorEmail = account.Email,
            DurationInMonths = internship.DurationInMonths,
            MaxEnrolledInterns = internship.MaxInternsToEnroll,
            ScheduledToStartDate = internship.ScheduledStartDate,
            EstimatedGraduationDate = internship.EstimatedGraduationDate,
            InternshipStatus = EnumRetrievalHelper.ConvertEnumValue(internship.InternshipStatus)
        };
    }
}