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
    [Migration("20240206121702_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Nexu_SMS.Entity.ClassModel", b =>
                {
                    b.Property<string>("ClassId")
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Class Name");

                    b.Property<string>("Schedule")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Schedule");

                    b.Property<string>("Student")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Teacherid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClassId");

                    b.ToTable("classModels");
                });

            modelBuilder.Entity("Nexu_SMS.Entity.Exam", b =>
                {
                    b.Property<int>("exam_Id")
                        .HasColumnType("int");

                    b.Property<string>("class_Id")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("examTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("exam_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sub_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("exam_Id");

                    b.HasIndex("class_Id");

                    b.HasIndex("sub_id");

                    b.ToTable("exams");
                });

            modelBuilder.Entity("Nexu_SMS.Entity.Result", b =>
                {
                    b.Property<int>("Res_Id")
                        .HasColumnType("int");

                    b.Property<int>("exam_Id")
                        .HasColumnType("int");

                    b.Property<float>("marks")
                        .HasColumnType("real");

                    b.Property<string>("stu_id")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Res_Id");

                    b.HasIndex("exam_Id");

                    b.HasIndex("stu_id");

                    b.ToTable("results");
                });

            modelBuilder.Entity("Nexu_SMS.Entity.Student", b =>
                {
                    b.Property<string>("id")
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.Property<DateTime>("dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("fName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("First Name");

                    b.Property<string>("lName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Last Name");

                    b.HasKey("id");

                    b.ToTable("students");
                });

            modelBuilder.Entity("Nexu_SMS.Entity.Subject", b =>
                {
                    b.Property<string>("sub_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("sub_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("sub_Id");

                    b.ToTable("sub");
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

            modelBuilder.Entity("Nexu_SMS.Entity.Exam", b =>
                {
                    b.HasOne("Nexu_SMS.Entity.ClassModel", "classModels")
                        .WithMany()
                        .HasForeignKey("class_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nexu_SMS.Entity.Subject", "sub")
                        .WithMany()
                        .HasForeignKey("sub_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("classModels");

                    b.Navigation("sub");
                });

            modelBuilder.Entity("Nexu_SMS.Entity.Result", b =>
                {
                    b.HasOne("Nexu_SMS.Entity.Exam", "exam")
                        .WithMany()
                        .HasForeignKey("exam_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nexu_SMS.Entity.Student", "student")
                        .WithMany()
                        .HasForeignKey("stu_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("exam");

                    b.Navigation("student");
                });
#pragma warning restore 612, 618
        }
    }
}