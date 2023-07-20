﻿namespace ProgrammingInternshipPlatform.Application.Helpers;

public class JwtSettings
{
    public string SigningKey { get;  set; } = null!;
    public string Issuer { get;  set; } = null!;
    public string[] Audiences { get;  set; } = null!;
}