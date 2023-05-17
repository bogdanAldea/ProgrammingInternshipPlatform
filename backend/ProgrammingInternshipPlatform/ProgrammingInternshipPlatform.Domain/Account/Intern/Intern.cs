﻿using ProgrammingInternshipPlatform.Domain.Account.UserAccount;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Internship;

namespace ProgrammingInternshipPlatform.Domain.Account.Intern;

public class Intern
{
    public Intern() {}
    
    public InternId Id { get; private set; }
    public AccountId AccountId { get; private set; }
    public InternshipId InternshipId { get; private set; }
    public UserAccount.UserAccount Account { get; set; } = null!;
}