﻿using System.ComponentModel.DataAnnotations;
using ProgrammingInternshipPlatform.Api.RequestAttributes;
using ProgrammingInternshipPlatform.Domain.Shared.Validators;

namespace ProgrammingInternshipPlatform.Api.Contracts.InternshipContracts.Requests;

public class InternshipPostDto
{
    [Required]
    public Guid LocationId { get; set; }
    
    [Required]
    [MinValue(RuleConstants.InternshipConstants.MinInternsToEnrol)]
    public int MaximumInternsToEnroll { get; set; }
    
    [Required]
    [MinValue(RuleConstants.InternshipConstants.MinDurationInMonths)]
    public int DurationInMonths { get; set; }
    
    [Required]
    public DateTime ScheduledToStartOnDate { get; set; }
    
    [Required]
    public DateTime ScheduledToEndOnDate { get; set; }
}