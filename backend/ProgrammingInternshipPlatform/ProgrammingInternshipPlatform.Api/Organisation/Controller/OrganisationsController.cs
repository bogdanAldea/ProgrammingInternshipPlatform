using Microsoft.AspNetCore.Mvc;
using ProgrammingInternshipPlatform.Api.API.Constants;
using ProgrammingInternshipPlatform.Api.API.Controllers;
using ProgrammingInternshipPlatform.Api.Organisation.Contracts.Responses;
using ProgrammingInternshipPlatform.Application.Account;
using ProgrammingInternshipPlatform.Application.Account.ViewUserAccounts;
using ProgrammingInternshipPlatform.Application.InternshipManagement.GetInternshipsByOrganisation;
using ProgrammingInternshipPlatform.Application.Organisation;
using ProgrammingInternshipPlatform.Domain.Organisation.Companies;

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
            return Ok(result.Payload);
        }

        return HandleApiErrorResponse(result.FailureReason);
    }

    [HttpGet]
    [Route(ApiRoutes.OrganisationRoutes.AllUserAccounts)]
    public async Task<IActionResult> GetAllUserAccount(Guid id)
    {
        var allAccountsAtOrganisationQuery = new GetAllUserAccountsAtCompanyQuery(id);
        var handlerResult = await Mediator.Send(allAccountsAtOrganisationQuery);
        if (handlerResult.IsSuccess)
        {
            return Ok(handlerResult.Payload);
        }

        return HandleApiErrorResponse(handlerResult.FailureReason);
    }

    [HttpGet]
    [Route(ApiRoutes.OrganisationRoutes.Countries.AllCountries)]
    public async Task<IActionResult> GetAllCountries(Guid id)
    {
        var allCountriesInOrganisationQuery = new GetAllCountriesInOrganisationQuery(id);
        var handlerResult = await Mediator.Send(allCountriesInOrganisationQuery);
        if (handlerResult.IsSuccess)
        {
            var mappedCountries = handlerResult.Payload!
                .Select(CountryResponse.MapFromCountry);
            return Ok(mappedCountries);
        }

        return HandleApiErrorResponse(handlerResult.FailureReason);
    }

    [HttpGet]
    [Route(ApiRoutes.OrganisationRoutes.Countries.AllCentersFromCountry)]
    public async Task<IActionResult> GetAllCentersInCountry(Guid id, Guid countryId)
    {
        var allCentersInCountryQuery = new GetAllCentersInCountryQuery(CompanyId: id, CountryId: countryId);
        var handlerResult = await Mediator.Send(allCentersInCountryQuery);
        if (handlerResult.IsSuccess)
        {
            var mappedCenters = handlerResult.Payload!
                .Select(CenterResponse.MapFromCenter);
            return Ok(mappedCenters);
        }

        return HandleApiErrorResponse(handlerResult.FailureReason);
    }
}