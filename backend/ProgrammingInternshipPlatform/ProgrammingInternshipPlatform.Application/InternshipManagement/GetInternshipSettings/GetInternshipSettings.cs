using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Application.InternshipManagement.GetInternshipSettings.Responses;
using ProgrammingInternshipPlatform.Application.ResultPattern;
using ProgrammingInternshipPlatform.Dal.Context;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships;

namespace ProgrammingInternshipPlatform.Application.InternshipManagement.GetInternshipSettings;

public record GetInternshipSettingsQuery(Guid InternshipId) : IRequest<HandlerResult<InternshipSettings>>;

public class GetInternshipSettingsHandler : IRequestHandler<GetInternshipSettingsQuery, HandlerResult<InternshipSettings>>
{
    private readonly ProgrammingInternshipPlatformDbContext _context;

    public GetInternshipSettingsHandler(ProgrammingInternshipPlatformDbContext context)
    {
        _context = context;
    }
    public async Task<HandlerResult<InternshipSettings>> Handle(GetInternshipSettingsQuery request, CancellationToken cancellationToken)
    {
        var internshipSettings = await SelectInternshipWithCenterName(request.InternshipId, cancellationToken);

        if (internshipSettings is null)
        {
            return HandleNotFoundInternshipError();
        }
        
        return HandlerResult<InternshipSettings>.Success(internshipSettings);
    }

    private async Task<InternshipSettings?> SelectInternshipWithCenterName(Guid internshipId, CancellationToken cancellationToken)
    {
        return await _context.Internships
            .Where(internship => internship.Id == new InternshipId(internshipId))
            .Join(
                _context.Companies,
                internship => internship.CompanyId,
                company => company.Id,
                (internship, company) => new
                {
                    Internship = internship,
                    Centers = company.Countries.SelectMany(country => country.Centers)
                }
            )
            .SelectMany(
                queryResult => queryResult.Centers,
                (result, center) => new { CenterName = center.Location, Internship = result.Internship }
            )
            .Select(result =>
                new InternshipSettings(
                    result.Internship.Id.Value,
                    result.Internship.Status,
                    result.Internship.MaximumInternsToEnroll,
                    result.Internship.DurationInMonths,
                    result.Internship.Timeframe.ScheduledToStartOn,
                    result.Internship.Timeframe.ScheduledToEndOn,
                    result.CenterName)
            )
            .SingleOrDefaultAsync(cancellationToken);
    }

    private HandlerResult<InternshipSettings> HandleNotFoundInternshipError()
    {
        var error = ApplicationError.NotFoundFailure(ApplicationErrorMessages.InternshipMessages
            .InternshipNotFound);
        return HandlerResult<InternshipSettings>.Fail(error);
    }
}