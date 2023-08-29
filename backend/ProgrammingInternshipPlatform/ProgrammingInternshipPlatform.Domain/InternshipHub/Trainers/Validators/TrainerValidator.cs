using FluentValidation;
using ProgrammingInternshipPlatform.Domain.InternshipHub.Trainers.Models;
using ProgrammingInternshipPlatform.Domain.Shared.Validators;

namespace ProgrammingInternshipPlatform.Domain.InternshipHub.Trainers.Validators;

public class TrainerValidator : DomainAbstractValidator<Trainer>
{
    public TrainerValidator()
    {
        RuleFor(trainer => trainer.Id)
            .NotEmpty();

        RuleFor(trainer => trainer.AccountId)
            .NotEmpty();

        RuleFor(trainer => trainer.TechnologyStack)
            .NotEmpty();
    }
}