﻿namespace ProgrammingInternshipPlatform.Application.ResultPattern;

public static class FailureMessages
{
    public static class Internship
    {
        public const string InternshipNotFound = 
            "The internship could not be found.";
        
        public const string MaximumInternsReached =
            "The maximum number of interns to enroll that has been set is was reached.";
        
        public const string InternAlreadyEnrolled = 
            "The intern you tried to enroll was already enrolled.";
        
        public const string InternshipSetUpPhaseHasPassed =
            "The internship is no longer in the setup phase so no interns can be enrolled anymore.";
    }
    
    public static class Account
    {
        public const string RoleNotFound = 
            "This role could not be found.";
    }
}