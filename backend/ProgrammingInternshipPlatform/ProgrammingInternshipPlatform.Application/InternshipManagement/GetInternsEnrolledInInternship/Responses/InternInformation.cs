namespace ProgrammingInternshipPlatform.Application.InternshipManagement.GetInternsEnrolledInInternship.Responses;

public class InternInformation
{
    public Guid InternId { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string? PictureUrl { get; }
    public DateTime JoiningDate { get;  }

    public InternInformation(Guid internId, string firstName, string lastName, string? pictureUrl, DateTime joiningDate)
    {
        InternId = internId;
        FirstName = firstName;
        LastName = lastName;
        PictureUrl = pictureUrl;
        JoiningDate = joiningDate;
    }
}