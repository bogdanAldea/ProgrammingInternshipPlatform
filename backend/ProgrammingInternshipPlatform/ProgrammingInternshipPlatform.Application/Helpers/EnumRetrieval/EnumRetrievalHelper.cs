using System.Text.RegularExpressions;

namespace ProgrammingInternshipPlatform.Application.Helpers.EnumRetrieval;

public static class EnumRetrievalHelper
{
    public static string ConvertPascalToReadable(string toConvert)
    {
        return Regex.Replace(toConvert, @"(\B[A-Z])", " $1");
    }
    
    public static Converted<TEnum> ConvertEnumValue<TEnum>(TEnum value) where TEnum : Enum
    {
        return new Converted<TEnum>
        {
            Name = ConvertPascalToReadable(value.ToString()),
            Value = value
        };
    }

    public static IReadOnlyList<Converted<TEnum>> GetAllEnumValues<TEnum>() where TEnum : Enum
    {
        var convertedEnumValues = new List<Converted<TEnum>>();
        foreach (TEnum value in Enum.GetValues(typeof(TEnum)))
        {
            var converted = new Converted<TEnum>
            {
                Name = ConvertPascalToReadable(value.ToString()),
                Value = value
            };
            
            convertedEnumValues.Add(converted);
        }

        return convertedEnumValues;
    }
}