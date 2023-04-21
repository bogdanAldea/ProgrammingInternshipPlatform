using ProgrammingInternshipPlatform.Domain.Account.Identifiers;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Identifiers;

namespace ProgrammingInternshipPlatform.Domain.InternshipManagement.Models;

public class Mentorship
{
    public Mentorship() {}
    
    public MentorshipId Id { get; set; }
    public TrainerId TrainerId { get; set; }
    public InternId InternId { get; set; }
    public InternshipId InternshipId { get; set; }
}