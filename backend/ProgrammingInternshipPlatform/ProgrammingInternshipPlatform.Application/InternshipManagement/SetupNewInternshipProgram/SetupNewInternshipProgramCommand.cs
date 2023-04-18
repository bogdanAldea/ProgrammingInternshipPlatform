﻿using MediatR;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Domain.Internships.Models;
using ProgrammingInternshipPlatform.Domain.Locations.Identifiers;

namespace ProgrammingInternshipPlatform.Application.InternshipManagement.SetupNewInternshipProgram;

public class SetupNewInternshipProgramCommand : IRequest<HandlerResult<Internship>>
{

    public SetupNewInternshipProgramCommand(LocationId locationId, int maximumInternsToEnroll, 
        int durationInMonths, DateTime scheduledToStartOnDate, DateTime scheduledToEndOnDate)
    {
        LocationId = locationId;
        MaximumInternsToEnroll = maximumInternsToEnroll;
        DurationInMonths = durationInMonths;
        ScheduledToStartOnDate = scheduledToStartOnDate;
        ScheduledToEndOnDate = scheduledToEndOnDate;
    }

    public LocationId LocationId { get; }
    public int MaximumInternsToEnroll { get; }
    public int DurationInMonths { get; }
    public DateTime ScheduledToStartOnDate { get; }
    public DateTime ScheduledToEndOnDate { get; }
}