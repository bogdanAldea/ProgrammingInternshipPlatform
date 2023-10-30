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
    [Migration("20231023135646_ModuleManagement")]
    partial class ModuleManagement
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Assignments.Models.Assignment", b =>
                {
                    b.Property<Guid>("AssignmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("LessonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AssignmentId");

                    b.HasIndex("LessonId")
                        .IsUnique();

                    b.ToTable("Assignments", (string)null);
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.LearningResources.Models.LearningResource", b =>
                {
                    b.Property<Guid>("LearningResourceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LessonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ResourceType")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LearningResourceId");

                    b.HasIndex("LessonId");

                    b.ToTable("LearningResources", (string)null);
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Lessons.Models.Lesson", b =>
                {
                    b.Property<Guid>("LessonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("TopicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TopicOrder")
                        .HasColumnType("int");

                    b.HasKey("LessonId");

                    b.HasIndex("TopicId");

                    b.ToTable("Lessons", (string)null);
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Topics.Models.Topic", b =>
                {
                    b.Property<Guid>("TopicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("SyllabusOrder")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TopicType")
                        .HasColumnType("int");

                    b.Property<int>("VersioningState")
                        .HasColumnType("int");

                    b.HasKey("TopicId");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.ModuleManagement.Models.Module", b =>
                {
                    b.Property<Guid>("ModuleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TopicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("VersionNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("VersionedByUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("VersionedOnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ModuleId");

                    b.HasIndex("VersionNumber")
                        .IsUnique();

                    b.ToTable("Module");
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Assignments.Models.Assignment", b =>
                {
                    b.HasOne("ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Lessons.Models.Lesson", null)
                        .WithOne("Assignment")
                        .HasForeignKey("ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Assignments.Models.Assignment", "LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.LearningResources.Models.LearningResource", b =>
                {
                    b.HasOne("ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Lessons.Models.Lesson", null)
                        .WithMany("LearningResources")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Lessons.Models.Lesson", b =>
                {
                    b.HasOne("ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Topics.Models.Topic", null)
                        .WithMany("Lessons")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Lessons.Models.Lesson", b =>
                {
                    b.Navigation("Assignment");

                    b.Navigation("LearningResources");
                });

            modelBuilder.Entity("ProgrammingInternshipPlatform.Domain.GeneralCurriculumManagement.Topics.Models.Topic", b =>
                {
                    b.Navigation("Lessons");
                });
#pragma warning restore 612, 618
        }
    }
}
