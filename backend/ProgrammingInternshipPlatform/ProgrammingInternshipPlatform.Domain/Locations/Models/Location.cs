﻿using ProgrammingInternshipPlatform.Domain.Account.Identifiers;
using ProgrammingInternshipPlatform.Domain.Account.Models;
using ProgrammingInternshipPlatform.Domain.Locations.Identifiers;

namespace ProgrammingInternshipPlatform.Domain.Locations.Models;

public class Location
{
    public Location() {}

    public LocationId Id { get; private set; }
    public CompanyId CompanyId { get; private set; }
    public string Center { get; private set; } = null!;
    public string Country { get; private set; } = null!;
}