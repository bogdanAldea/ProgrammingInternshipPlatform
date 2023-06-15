using Microsoft.AspNetCore.Mvc;
using ProgrammingInternshipPlatform.Api.API.Constants;
using ProgrammingInternshipPlatform.Api.API.Controllers;
using ProgrammingInternshipPlatform.Api.Organisation.Contracts.Responses;
using ProgrammingInternshipPlatform.Application.InternshipManagement.GetInternshipsByOrganisation;
using ProgrammingInternshipPlatform.Domain.Organization.Companys;

namespace ProgrammingInternshipPlatform.Api.Organisation.Controller;

public class OrganisationsController : ApiController
{
    [HttpGet]
    [Route(ApiRoutes.OrganisationRoutes.AllInternships)]
    public async Task<IActionResult> GetAllInternshipsBelongingToOrganisation(Guid id)
    {
        var internshipsOfOrganisationQuery = new GetInternshipByOrganisationQuery(new CompanyId(id));
        var result = await Mediator.Send(internshipsOfOrganisationQuery);
        if (result.IsSuccess)
        {
            var mappedInternships = new List<InternshipDetail>();
            result.Payload!.ForEach(internship => mappedInternships.Add(InternshipDetail.MapFromInternship(internship)));
            return Ok(mappedInternships);
        }

        return HandleApiErrorResponse(result.FailureReason);
    }
}