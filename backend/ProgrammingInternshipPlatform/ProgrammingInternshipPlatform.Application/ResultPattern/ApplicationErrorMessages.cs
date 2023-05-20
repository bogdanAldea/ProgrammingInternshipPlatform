﻿namespace ProgrammingInternshipPlatform.Application.ResultPattern;

public static class ApplicationErrorMessages
{
    public static class InternshipMessages
    {
        public const string InternshipNotFound = "The internship could not be found.";
    }

    public static class UserAccount
    {
        public const string EmailAlreadyRegistered = "An user with this email is already registered.";
        public const string UserAccountNotFound = "The user account you tried to access could not be found.";
    }

    public static class Project
    {
        public const string ProjectNotFound = "The project you tried to access could not be found.";
    }
    
    public static class Board
    {
        public const string BoardNotFound = "The Backlog board you tried to access could not be found.";
    }
}