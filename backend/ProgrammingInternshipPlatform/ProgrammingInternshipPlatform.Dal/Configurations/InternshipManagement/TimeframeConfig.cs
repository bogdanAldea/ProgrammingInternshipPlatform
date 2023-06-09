﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingInternshipPlatform.Domain.InternshipManagement.Timeframes;

namespace ProgrammingInternshipPlatform.Dal.Configurations.InternshipManagement;

public class TimeframeConfig : IEntityTypeConfiguration<Timeframe>
{
    public void Configure(EntityTypeBuilder<Timeframe> builder)
    {
        builder.HasKey(timeframe => timeframe.Id);
        builder.Property(timeframe => timeframe.Id)
            .HasConversion(id => id.Value, 
                value => new TimeframeId(value));

        builder.Property(timeframe => timeframe.ScheduledToStartOn)
            .IsRequired();

        builder.Property(timeframe => timeframe.ScheduledToEndOn)
            .IsRequired();
    }
}