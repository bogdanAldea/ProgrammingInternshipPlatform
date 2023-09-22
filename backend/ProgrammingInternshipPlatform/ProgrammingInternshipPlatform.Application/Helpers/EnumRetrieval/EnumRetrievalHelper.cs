using System.Text.RegularExpressions;

namespace ProgrammingInternshipPlatform.Application.Helpers.EnumRetrieval;

public static class EnumRetrievalHelper
{
    public static string ConvertPascalToReadable(string toConvert)
    {
        return Regex.Replace(toConvert, @"(\B[A-Z])", " $1");
    }
    
    public static DomainEnumConverted<TEnum> ConvertEnumValue<TEnum>(TEnum value) where TEnum : Enum
    {
        return new DomainEnumConverted<TEnum>
        {
            Name = ConvertPascalToReadable(value.ToString()),
            Value = value
        };
    }

    public static IReadOnlyList<DomainEnumConverted<TEnum>> GetAllEnumValues<TEnum>() where TEnum : Enum
    {
        var convertedEnumValues = new List<DomainEnumConverted<TEnum>>();
        foreach (TEnum value in Enum.GetValues(typeof(TEnum)))
        {
            var converted = new DomainEnumConverted<TEnum>
            {
                Name = ConvertPascalToReadable(value.ToString()),
                Value = value
            };
            
            convertedEnumValues.Add(converted);
        }

        return convertedEnumValues;
    }
}