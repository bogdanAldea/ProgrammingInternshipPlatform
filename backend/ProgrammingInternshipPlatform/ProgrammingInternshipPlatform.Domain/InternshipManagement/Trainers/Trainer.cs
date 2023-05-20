using ProgrammingInternshipPlatform.Domain.Account.UserAccounts;

namespace ProgrammingInternshipPlatform.Domain.InternshipManagement.Trainers;

public class Trainer
{
    public TrainerId Id { get; private set; }
    public AccountId AccountId { get; private set; }
}