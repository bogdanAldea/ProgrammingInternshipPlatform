using ProgrammingInternshipPlatform.Domain.Account.UserAccount;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internship;

namespace ProgrammingInternshipPlatform.Domain.Account.Trainer;

public class Trainer
{
    public TrainerId Id { get; private set; }
    public AccountId AccountId { get; private set; }
    public UserAccount.UserAccount Account { get; private set; }

}