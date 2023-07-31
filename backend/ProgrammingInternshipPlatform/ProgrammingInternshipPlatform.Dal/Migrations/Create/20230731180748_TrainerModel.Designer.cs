﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProgrammingInternshipPlatform.Dal.Context;

#nullable disable

namespace ProgrammingInternshipPlatform.Dal.Migrations.Create
{
    [DbContext(typeof(ProgrammingInternshipPlatformDbContext))]
    [Migration("20230731180748_TrainerModel")]
    partial class TrainerModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("InternshipTrainer", b =>
                {
                    b.Property<Guid>("InternshipsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TrainersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("InternshipsId", "TrainersId");

                    b.HasIndex("TrainersId");

                    b.ToTable("InternshipTrainer");
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Models.Internship", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DurationInMonths")
                        .HasColumnType("int");

                    b.Property<DateTime>("EstimatedToEndOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaxInternsToEnroll")
                        .HasColumnType("int");

                    b.Property<DateTime>("ScheduledToStartOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Internships");
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.InternshipHub.Trainers.Models.Trainer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Trainer");
                });

            modelBuilder.Entity("InternshipTrainer", b =>
                {
                    b.HasOne("ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Models.Internship", null)
                        .WithMany()
                        .HasForeignKey("InternshipsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProgrammingInternshipPlatform.Domain.InternshipHub.Trainers.Models.Trainer", null)
                        .WithMany()
                        .HasForeignKey("TrainersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}