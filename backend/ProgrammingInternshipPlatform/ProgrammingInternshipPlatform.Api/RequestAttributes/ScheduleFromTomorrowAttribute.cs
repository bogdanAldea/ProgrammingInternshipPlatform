using System.ComponentModel.DataAnnotations;

namespace ProgrammingInternshipPlatform.Api.RequestAttributes;

public class ScheduleFromTomorrowAttribute : ValidationAttribute
{
    private const string ValidDateFormat = "yyyy-MM-dd";

    protected override ValidationResult? IsValid(object? incomingDateValue, ValidationContext validationContext)
    {
        if (incomingDateValue is not null)
        {
            DateTime incomingDateAsDate = (DateTime)incomingDateValue;
            DateTime scheduledFromTomorrowDate = incomingDateAsDate.AddDays(1);

            if (incomingDateAsDate.Date < scheduledFromTomorrowDate.Date)
            {
                return new ValidationResult("The Date must be rescheduled starting from tomorrow or later.");
            }
            
            return ValidationResult.Success;
        }

        return new ValidationResult("The date that needs to be rescheduled must be passed.");
    }
}