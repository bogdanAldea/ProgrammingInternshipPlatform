namespace ProgrammingInternshipPlatform.Api.InternshipHub.Contracts.Responses;

public class InternshipWithCoordinatorResponse
{
    public Member Coordinator { get; private set; } = null!;
    public InternshipPartialResponse Internship { get; private set; } = null!;

    public static InternshipWithCoordinatorResponse MapFrom(Application.InternshipHub.Responses.InternshipWithCoordinator response)
    {
        return new InternshipWithCoordinatorResponse
        {
            Coordinator = Member.MapFrom(response.Coordinator),
            Internship = InternshipPartialResponse.MapFrom(response.Internship)
        };
    }
}