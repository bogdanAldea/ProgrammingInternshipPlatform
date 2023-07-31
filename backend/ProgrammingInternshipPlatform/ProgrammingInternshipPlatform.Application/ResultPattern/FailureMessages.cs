namespace ProgrammingInternshipPlatform.Application.ResultPattern;

public static class FailureMessages
{
    public static class Internship
    {
        public const string InternshipNotFound = "The internship could not be found.";
        public const string MaximumInternsReached =
            "The maximum number of interns to enroll that has been set is was reached.";
        public const string InternAlreadyEnrolled = "The intern you tried to enroll was already enrolled.";
        public const string InternshipSetUpPhaseHasPassed =
            "The internship is no longer in the setup phase so no interns can be enrolled enymore.";
    }

    public static class UserAccount
    {
        public const string EmailAlreadyRegistered = "An user with this email is already registered.";
        public const string UserAccountNotFound = "The user account you tried to access could not be found.";
        public const string EmailNotFoundForUser = "User with this email could not be found.";
        public const string PasswordNotValid = "Password is not valid.";
        public const string InvalidRequestedRoles = "One or more roles requested to add to user are invalid.";
        public const string RoleNotFound = "Role was not found in the system.";
        public const string AccountIdentityNotFound = "Identity for this user could not be found.";
    }
    
    public static class Company
    {
        public const string CompanyNotFound = "This company could not be found.";
    }
}