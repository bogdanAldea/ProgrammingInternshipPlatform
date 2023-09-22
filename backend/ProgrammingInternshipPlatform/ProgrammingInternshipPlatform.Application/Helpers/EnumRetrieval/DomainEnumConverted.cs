namespace ProgrammingInternshipPlatform.Application.Helpers.EnumRetrieval;

public class DomainEnumConverted<TEnum> where TEnum : Enum
{
    public string Name { get; set; }
    public TEnum Value { get; set; }
}