using ProgrammingInternshipPlatform.Domain.InternshipHub.Interns.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Mentorships.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Trainers.Identifiers;

namespace ProgrammingInternshipPlatform.Domain.InternshipHub.Mentorships.Models;

public class Mentorship
{
    public MentorshipId Id { get; private set; }
    public TrainerId TrainerId { get; private set; }
    public InternId InternId { get; private set; }
    public InternshipId InternshipId { get; private set; }
}