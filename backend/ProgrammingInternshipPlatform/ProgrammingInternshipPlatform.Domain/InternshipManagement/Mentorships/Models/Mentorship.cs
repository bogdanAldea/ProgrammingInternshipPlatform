using ProgrammingInternshipPlatform.Domain.InternshipManagement.Interns.Models;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships.Models;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Trainers.Models;

namespace ProgrammingInternshipPlatform.Domain.InternshipManagement.Mentorships.Models;

public class Mentorship
{
    public MentorshipId MentorshipId { get; private set; }
    public TrainerId TrainerId { get; private set; }
    public InternId InternId { get; private set; }
    public InternshipId InternshipId { get; private set; }
}