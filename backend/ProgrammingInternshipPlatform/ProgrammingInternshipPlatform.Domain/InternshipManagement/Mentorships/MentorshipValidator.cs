using FluentValidation;
using ProgrammingInternshipPlatform.Domain.Shared.Validators;

namespace ProgrammingInternshipPlatform.Domain.InternshipManagement.Mentorships;

public class MentorshipValidator : DomainAbstractValidator<Mentorship>
{
    public MentorshipValidator()
    {
        RuleFor(mentorship => mentorship.InternId)
            .NotEmpty();

        RuleFor(mentorship => mentorship.TrainerId)
            .NotEmpty();

        RuleFor(mentorship => mentorship.InternshipId)
            .NotEmpty();
    }
}