using ProgrammingInternshipPlatform.Domain.Account.Trainer;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internship;

namespace ProgrammingInternshipPlatform.Domain.Account.TrainerDesignation;

public class TrainerDesignation
{
    public TrainerDesignationId Id { get; private set; }
    public TrainerId TrainerId { get; private set; }
    public InternshipId InternshipId { get; private set; }
    public DateTime DesignatedOn { get; private set; }
}