using ProgrammingInternshipPlatform.Domain.InternshipManagement.Interns;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Trainers;

namespace ProgrammingInternshipPlatform.Domain.InternshipManagement.Mentorships;

public class Mentorship
{
    private static readonly MentorshipValidator Validator = new();

    public Mentorship()
    {
    }

    public MentorshipId Id { get; private set; }
    public TrainerId TrainerId { get; private set; }
    public InternId InternId { get; private set; }
    public InternshipId InternshipId { get; private set; }

    public static async Task<Mentorship> CreateNew(TrainerId trainerId, InternId internId,
        InternshipId internshipId, CancellationToken cancellationToken)
    {
        var mentorship = new Mentorship()
        {
            Id = new MentorshipId(Guid.NewGuid()),
            TrainerId = trainerId,
            InternId = internId,
            InternshipId = internshipId
        };
        await Validator.ValidateDomainModelAsync(mentorship, cancellationToken);
        return mentorship;
    }
}