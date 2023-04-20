using Microsoft.AspNetCore.Identity;
using ProgrammingInternshipPlatform.Domain.Account.Identifiers;
namespace ProgrammingInternshipPlatform.Domain.Account.Models;

public class Trainer
{
    public Trainer() {}

    public TrainerId Id { get; private set; }
    public AccountId AccountId { get; private set; }
    public UserAccount Account { get; private set; } = null!;
}