using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships.Models;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Trainers.Models;

namespace ProgrammingInternshipPlatform.Domain.InternshipManagement;

public class AssignedTrainer
{
    public InternshipId InternshipId { get; set; }
    public TrainerId TrainerId { get; set; }
}