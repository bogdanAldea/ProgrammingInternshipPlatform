namespace ProgrammingInternshipPlatform.Domain.GeneralCurriculum.ValidationConstants;

public static class ChapterRuleFailureMessages
{
    public const string IdNullOrEmpty = "Chapter Id must be provided.";
    public const string ChapterTitleTooLong = "{PropertyName} must be at least {PropertyValue} in length.";
    public const string ChapterTitleNotProvided = "{PropertyName} cannot be empty.";
    public const string ChapterDescriptionTooLong = "{PropertyName} must be at least {PropertyValue} in length.";
    public const string ChapterDescriptionNotProvided = "{PropertyName} cannot be empty.";
}