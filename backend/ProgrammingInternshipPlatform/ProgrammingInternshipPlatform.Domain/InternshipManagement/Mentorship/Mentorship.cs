using ProgrammingInternshipPlatform.Domain.Account.Intern;
using ProgrammingInternshipPlatform.Domain.Account.Trainer;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internship;

namespace ProgrammingInternshipPlatform.Domain.InternshipManagement.Mentorship;

public class Mentorship
{
    public Mentorship() {}
    
    public MentorshipId Id { get; private set; }
    public TrainerId TrainerId { get; private set; }
    public InternId InternId { get; private set; }
    public InternshipId InternshipId { get; private set; }

    public static Mentorship CreateMentorship(TrainerId trainerId, InternId internId, InternshipId internshipId)
    {
        return new Mentorship()
        {
            Id = new MentorshipId(Guid.NewGuid()),
            TrainerId = trainerId,
            InternId = internId,
            InternshipId = internshipId
        };
    }
}