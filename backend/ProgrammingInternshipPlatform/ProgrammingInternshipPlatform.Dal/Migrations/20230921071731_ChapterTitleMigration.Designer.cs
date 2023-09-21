﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProgrammingInternshipPlatform.Dal.Context;

#nullable disable

namespace ProgrammingInternshipPlatform.Dal.Migrations
{
    [DbContext(typeof(ProgrammingInternshipPlatformDbContext))]
    [Migration("20230921071731_ChapterTitleMigration")]
    partial class ChapterTitleMigration
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

            modelBuilder.Entity("InternshipVersionedCurriculum", b =>
                {
                    b.Property<Guid>("CurriculaVersionedCurriculumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InternshipsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CurriculaVersionedCurriculumId", "InternshipsId");

                    b.HasIndex("InternshipsId");

                    b.ToTable("InternshipVersionedCurriculum");
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Assignment.Model.Assignment", b =>
                {
                    b.Property<Guid>("AssignmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("LastUpdatedByAccount")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LessonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AssignmentId");

                    b.HasIndex("LessonId")
                        .IsUnique();

                    b.ToTable("Assignment");
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Models.Chapter", b =>
                {
                    b.Property<Guid>("ChapterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ChapterId");

                    b.ToTable("Chapter");
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Lesson.Model.Lesson", b =>
                {
                    b.Property<Guid>("LessonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChapterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("LessonId");

                    b.HasIndex("ChapterId");

                    b.ToTable("Lesson");
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.InternshipHub.Interns.Models.Intern", b =>
                {
                    b.Property<Guid>("InternId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InternshipId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("InternId");

                    b.HasIndex("InternshipId");

                    b.ToTable("Intern");
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Models.Internship", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Center")
                        .HasColumnType("int");

                    b.Property<Guid>("CoordinatorId")
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

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.InternshipHub.Mentorships.Models.Mentorship", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InternId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InternshipId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TrainerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("InternshipId");

                    b.ToTable("Mentorship");
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.InternshipHub.Trainers.Models.Trainer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Trainer");
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.InternshipHub.VersionedCurriculums.Modules.VersionedCurriculum", b =>
                {
                    b.Property<Guid>("VersionedCurriculumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("VersionedOnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("VersionedCurriculumId");

                    b.ToTable("VersionedCurriculum");
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.VersionedModules.Model.VersionedModule", b =>
                {
                    b.Property<Guid>("VersionedModuleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChapterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ReleaseVersionNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("VersionedCurriculumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("VersionedOnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("VersionedModuleId");

                    b.ToTable("VersionedModule");
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

            modelBuilder.Entity("InternshipVersionedCurriculum", b =>
                {
                    b.HasOne("ProgrammingInternshipPlatform.Domain.InternshipHub.VersionedCurriculums.Modules.VersionedCurriculum", null)
                        .WithMany()
                        .HasForeignKey("CurriculaVersionedCurriculumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Models.Internship", null)
                        .WithMany()
                        .HasForeignKey("InternshipsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Assignment.Model.Assignment", b =>
                {
                    b.HasOne("ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Lesson.Model.Lesson", null)
                        .WithOne("Assignment")
                        .HasForeignKey("ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Assignment.Model.Assignment", "LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Lesson.Model.Lesson", b =>
                {
                    b.HasOne("ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Models.Chapter", null)
                        .WithMany("Lessons")
                        .HasForeignKey("ChapterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.InternshipHub.Interns.Models.Intern", b =>
                {
                    b.HasOne("ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Models.Internship", null)
                        .WithMany("Interns")
                        .HasForeignKey("InternshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.InternshipHub.Mentorships.Models.Mentorship", b =>
                {
                    b.HasOne("ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Models.Internship", null)
                        .WithMany("Mentorships")
                        .HasForeignKey("InternshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Chapter.Models.Chapter", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.GeneralCurriculum.GeneralCurriculum.Lesson.Model.Lesson", b =>
                {
                    b.Navigation("Assignment")
                        .IsRequired();
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.InternshipHub.Internships.Models.Internship", b =>
                {
                    b.Navigation("Interns");

                    b.Navigation("Mentorships");
                });
#pragma warning restore 612, 618
        }
    }
}
