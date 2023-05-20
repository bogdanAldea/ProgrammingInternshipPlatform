using FluentValidation;
using ProgrammingInternshipPlatform.Domain.Shared.Validators;

namespace ProgrammingInternshipPlatform.Domain.ProjectHub.Projects;

public class ProjectValidator : DomainAbstractValidator<Project>
{
    public ProjectValidator()
    {
        RuleFor(project => project.ProjectId)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.ProjectMessages.EmptyOrNullProperty);

        RuleFor(project => project.InternId)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.ProjectMessages.EmptyOrNullProperty);

        RuleFor(project => project.ProjectStatus)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.ProjectMessages.EmptyOrNullProperty)
            .IsInEnum()
            .WithMessage(RuleFailureMessages.ProjectMessages.StatusNotAnEnumValue);

        RuleFor(project => project.StartedOn)
            .NotEmpty()
            .When(project => project.ProjectStatus == ProjectStatus.Ongoing)
            .WithMessage(RuleFailureMessages.ProjectMessages.StartDateNotSet);

        RuleFor(project => project.CompletedOn)
            .NotEmpty()
            .When(project => project.ProjectStatus == ProjectStatus.Completed)
            .WithMessage(RuleFailureMessages.ProjectMessages.CompletedDateNotSet);

        RuleFor(project => project.UrlLocation)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.ProjectMessages.EmptyOrNullProperty);

        RuleFor(project => project.Title)
            .NotEmpty()
            .WithMessage(RuleFailureMessages.ProjectMessages.EmptyOrNullProperty);
    }
}