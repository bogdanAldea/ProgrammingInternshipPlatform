namespace ProgrammingInternshipPlatform.Application.InternshipManagement.QueryParams;

public record InternshipQueryParams(int page, int resultsPerPage, int? InternshipStatus = null, DateTime? 
    ScheduledStartDate = null, DateTime? EstimatedGraduationDate = null);