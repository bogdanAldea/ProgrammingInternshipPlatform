using System.ComponentModel.DataAnnotations;
using ProgrammingInternshipPlatform.Application.Helpers.EnumRetrieval;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Enums;

namespace ProgrammingInternshipPlatform.Api.InternshipHub.Contracts.Requests;

public class TrainerDelegationRequest
{
    [Required] 
    public Guid AccountId { get; init; }

    [Required]
    public IReadOnlyCollection<Converted<TechnologyStack>> Technologies { get; init; } =
        new List<Converted<TechnologyStack>>();
}