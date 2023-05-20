using ProgrammingInternshipPlatform.Domain.InternshipManagement.Interns;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Trainers;

namespace ProgrammingInternshipPlatform.Domain.InternshipManagement.Mentorships;

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