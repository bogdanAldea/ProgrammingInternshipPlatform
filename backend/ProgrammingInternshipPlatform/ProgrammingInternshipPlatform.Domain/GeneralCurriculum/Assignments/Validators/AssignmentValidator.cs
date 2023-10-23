using FluentValidation;
using ProgrammingInternshipPlatform.Domain.GeneralCurriculum.Assignments.Models;
using ProgrammingInternshipPlatform.Domain.Shared.Validators;

namespace ProgrammingInternshipPlatform.Domain.GeneralCurriculum.Assignments.Validators;

public class AssignmentValidator : DomainAbstractValidator<Assignment>
{
    public AssignmentValidator()
    {
        RuleFor(assignment => assignment.AssignmentId)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.PropertyMustExist);
        
        RuleFor(assignment => assignment.LessonId)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.PropertyMustExist);

        RuleFor(assignment => assignment.Title)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.PropertyMustExist)
            .MaximumLength(RuleConstants.GeneralCurriculum.AssignmentTitleMaxLength)
            .WithMessage(RuleFailureMessages.PropertyLenghtTooLong);

        RuleFor(assignment => assignment.Description)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.PropertyMustExist)
            .MaximumLength(RuleConstants.GeneralCurriculum.AssignmentDescriptionMaxLength)
            .WithMessage(RuleFailureMessages.PropertyLenghtTooLong);
    }
}