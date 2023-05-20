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
    [Migration("20230520072638_AssignmentEntityAndConfigMigration")]
    partial class AssignmentEntityAndConfigMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.Account.UserAccounts.UserAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdentityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("JoiningDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserAccount");
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.Curriculum.Assignments.Assignment", b =>
                {
                    b.Property<Guid>("AssignmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("LessonId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AssignmentId");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("LessonId")
                        .IsUnique();

                    b.ToTable("Assignment");
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.Curriculum.Lessons.Lesson", b =>
                {
                    b.Property<Guid>("LessonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(560)
                        .HasColumnType("nvarchar(560)");

                    b.Property<Guid>("ModuleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("LessonId");

                    b.HasIndex("Description")
                        .IsUnique();

                    b.HasIndex("LessonId");

                    b.HasIndex("ModuleId");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Lesson");
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.Curriculum.Modules.Module", b =>
                {
                    b.Property<Guid>("ModuleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(560)
                        .HasColumnType("nvarchar(560)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ModuleId");

                    b.HasIndex("Description")
                        .IsUnique();

                    b.HasIndex("ModuleId");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Module");
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.InternshipManagement.Interns.Intern", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InternshipId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("InternshipId");

                    b.ToTable("Intern");
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships.Internship", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DurationInMonths")
                        .HasColumnType("int");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MaximumInternsToEnroll")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId")
                        .IsUnique();

                    b.ToTable("Internships");
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.InternshipManagement.Mentorships.Mentorship", b =>
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

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.InternshipManagement.Timeframes.Timeframe", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InternshipId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ScheduledToEndOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ScheduledToStartOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("InternshipId")
                        .IsUnique();

                    b.ToTable("Timeframe");
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.InternshipManagement.Trainers.Trainer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Trainer");
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.Organization.Center.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Center")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Center")
                        .IsUnique();

                    b.HasIndex("CompanyId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.Organization.Companys.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.ProjectHub.Boards.Board", b =>
                {
                    b.Property<Guid>("BoardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OwnerIntern")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BoardId");

                    b.HasIndex("BoardId");

                    b.HasIndex("ProjectId")
                        .IsUnique();

                    b.ToTable("Board");
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.ProjectHub.Cards.Card", b =>
                {
                    b.Property<Guid>("CardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AddedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Local));

                    b.Property<int>("ComplexityLabel")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PriorityLabel")
                        .HasColumnType("int");

                    b.Property<int?>("RiskLabel")
                        .HasColumnType("int");

                    b.Property<Guid>("StageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TypeLabel")
                        .HasColumnType("int");

                    b.HasKey("CardId");

                    b.HasIndex("CardId");

                    b.HasIndex("Description")
                        .IsUnique();

                    b.HasIndex("StageId");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Card");
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.ProjectHub.Projects.Project", b =>
                {
                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Documentation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("InternId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ProjectStatus")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UrlLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.ProjectHub.Stages.Stage", b =>
                {
                    b.Property<Guid>("StageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BoardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StageId");

                    b.HasIndex("StageId");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.HasIndex("BoardId", "Order")
                        .IsUnique();

                    b.ToTable("Stage");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.Curriculum.Assignments.Assignment", b =>
                {
                    b.HasOne("ProgrammingInternshipPlatform.Domain.Curriculum.Lessons.Lesson", null)
                        .WithOne("Assignment")
                        .HasForeignKey("ProgrammingInternshipPlatform.Domain.Curriculum.Assignments.Assignment", "LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.Curriculum.Lessons.Lesson", b =>
                {
                    b.HasOne("ProgrammingInternshipPlatform.Domain.Curriculum.Modules.Module", null)
                        .WithMany("Lessons")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.InternshipManagement.Interns.Intern", b =>
                {
                    b.HasOne("ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships.Internship", null)
                        .WithMany("Interns")
                        .HasForeignKey("InternshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships.Internship", b =>
                {
                    b.HasOne("ProgrammingInternshipPlatform.Domain.Organization.Center.Location", null)
                        .WithOne()
                        .HasForeignKey("ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships.Internship", "LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.InternshipManagement.Mentorships.Mentorship", b =>
                {
                    b.HasOne("ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships.Internship", null)
                        .WithMany("Mentorships")
                        .HasForeignKey("InternshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.InternshipManagement.Timeframes.Timeframe", b =>
                {
                    b.HasOne("ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships.Internship", null)
                        .WithOne("Timeframe")
                        .HasForeignKey("ProgrammingInternshipPlatform.Domain.InternshipManagement.Timeframes.Timeframe", "InternshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.Organization.Center.Location", b =>
                {
                    b.HasOne("ProgrammingInternshipPlatform.Domain.Organization.Companys.Company", null)
                        .WithMany("Locations")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.ProjectHub.Boards.Board", b =>
                {
                    b.HasOne("ProgrammingInternshipPlatform.Domain.ProjectHub.Projects.Project", null)
                        .WithOne("Board")
                        .HasForeignKey("ProgrammingInternshipPlatform.Domain.ProjectHub.Boards.Board", "ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.ProjectHub.Cards.Card", b =>
                {
                    b.HasOne("ProgrammingInternshipPlatform.Domain.ProjectHub.Stages.Stage", null)
                        .WithMany("Cards")
                        .HasForeignKey("StageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.ProjectHub.Stages.Stage", b =>
                {
                    b.HasOne("ProgrammingInternshipPlatform.Domain.ProjectHub.Boards.Board", null)
                        .WithMany("Stages")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.Curriculum.Lessons.Lesson", b =>
                {
                    b.Navigation("Assignment")
                        .IsRequired();
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.Curriculum.Modules.Module", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.InternshipManagement.Internships.Internship", b =>
                {
                    b.Navigation("Interns");

                    b.Navigation("Mentorships");

                    b.Navigation("Timeframe")
                        .IsRequired();
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.Organization.Companys.Company", b =>
                {
                    b.Navigation("Locations");
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.ProjectHub.Boards.Board", b =>
                {
                    b.Navigation("Stages");
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.ProjectHub.Projects.Project", b =>
                {
                    b.Navigation("Board")
                        .IsRequired();
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.ProjectHub.Stages.Stage", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
