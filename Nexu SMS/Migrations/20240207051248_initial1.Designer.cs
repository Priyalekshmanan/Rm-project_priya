﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nexu_SMS.Entity;

#nullable disable

namespace Nexu_SMS.Migrations
{
    [DbContext(typeof(ContextClass))]
    [Migration("20240207051248_initial1")]
    partial class initial1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Nexu_SMS.Entity.ClassManagement", b =>
                {
                    b.Property<string>("ClassId")
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Class Name");

                    b.Property<string>("Teacherid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Teacher ID");

                    b.HasKey("ClassId");

                    b.ToTable("Class_Table");
                });

            modelBuilder.Entity("Nexu_SMS.Entity.Exam", b =>
                {
                    b.Property<string>("examId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Exam ID");

                    b.Property<string>("classId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Class ID");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2")
                        .HasColumnName("Exam Date");

                    b.Property<string>("examName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Exam Name");

                    b.Property<string>("examTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Exam Time");

                    b.Property<string>("subId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Subject ID");

                    b.HasKey("examId");

                    b.ToTable("exams");
                });

            modelBuilder.Entity("Nexu_SMS.Entity.Result", b =>
                {
                    b.Property<string>("ResultId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Result ID");

                    b.Property<string>("examId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Exam ID");

                    b.Property<float>("marks")
                        .HasColumnType("real")
                        .HasColumnName("Marks");

                    b.Property<string>("studentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Student ID");

                    b.Property<string>("subjectId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Subject ID");

                    b.HasKey("ResultId");

                    b.ToTable("results");
                });

            modelBuilder.Entity("Nexu_SMS.Entity.SAttendance", b =>
                {
                    b.Property<Guid>("attendanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.Property<string>("studentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("attendanceId");

                    b.ToTable("Student_Attendance_Table");
                });

            modelBuilder.Entity("Nexu_SMS.Entity.Student", b =>
                {
                    b.Property<string>("id")
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.Property<int>("clss")
                        .HasColumnType("int")
                        .HasColumnName("Class");

                    b.Property<DateTime>("dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("eMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("E-mail");

                    b.Property<string>("fName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("First Name");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Gender");

                    b.Property<string>("lName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Last Name");

                    b.Property<string>("number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Mobile No");

                    b.Property<string>("section")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Section");

                    b.HasKey("id");

                    b.ToTable("students");
                });

            modelBuilder.Entity("Nexu_SMS.Entity.Subject", b =>
                {
                    b.Property<string>("subId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Subject Id");

                    b.Property<string>("subName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Subject Name");

                    b.HasKey("subId");

                    b.ToTable("subjects");
                });

            modelBuilder.Entity("Nexu_SMS.Entity.TAttendance", b =>
                {
                    b.Property<Guid>("attendanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.Property<string>("teacherId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("attendanceId");

                    b.ToTable("Teacher_Attendance_Table");
                });

            modelBuilder.Entity("Nexu_SMS.Entity.Teacher", b =>
                {
                    b.Property<string>("teacherId")
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.Property<DateTime>("dateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("teacherAddress")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar");

                    b.Property<string>("teacherClass")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.Property<string>("teacherEmail")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.Property<string>("teacherFirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.Property<string>("teacherGender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar");

                    b.Property<string>("teacherLastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.Property<string>("teacherPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("teacherSubjectTaught")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.HasKey("teacherId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Nexu_SMS.Entity.Users", b =>
                {
                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.HasKey("userId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Nexu_SMS.Repository.AdmissionNo", b =>
                {
                    b.Property<string>("admissionNo")
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.HasKey("admissionNo");

                    b.ToTable("AdmissionNoTable");
                });
#pragma warning restore 612, 618
        }
    }
}