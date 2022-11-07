using System.ComponentModel.DataAnnotations;

namespace CustomDataAnnotation.Models;


public class Validation
{
    
}

public class DataGreaterThanToday : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        string error = validationContext.DisplayName + " can not be in the past";
        var dt = (DateTime)value;

        if (dt < DateTime.Now)
        {
            var mesage = FormatErrorMessage(error);
            return new ValidationResult(ErrorMessage);
        }
        return null;
    }
}

public class DateIsGreaterThan : ValidationAttribute
{
    public string CompareDate { get; set; }

    public DateIsGreaterThan(string compareDate)
    {
        CompareDate = compareDate;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        DateTime laterDate = (DateTime)value;
        
        // Important step to grab the value's property from the model
        DateTime earlierDate = (DateTime)validationContext.ObjectType.GetProperty(CompareDate)
            .GetValue(validationContext.ObjectInstance, null);

        if (laterDate > earlierDate)
        {
            return ValidationResult.Success;
        }
        else
        {
            return new ValidationResult("Departure date cannot be greater than final date");
        }

        return null;
    }
}
