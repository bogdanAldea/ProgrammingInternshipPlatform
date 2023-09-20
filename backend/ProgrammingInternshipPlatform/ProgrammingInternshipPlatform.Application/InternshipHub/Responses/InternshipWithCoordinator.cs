using ProgrammingInternshipPlatform.Domain.Accounts.Models;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Models;
using Account = ProgrammingInternshipPlatform.Application.Abstractions.GraphApi.Responses.Account;

namespace ProgrammingInternshipPlatform.Application.InternshipHub.Responses;

public class InternshipWithCoordinator
{
    public Account Coordinator { get; set; }
    public Internship Internship { get; set; }
}