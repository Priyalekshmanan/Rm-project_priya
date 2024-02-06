using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nexu_SMS.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdmissionNoTable",
                columns: table => new
                {
                    admissionNo = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmissionNoTable", x => x.admissionNo);
                });

            migrationBuilder.CreateTable(
                name: "classModels",
                columns: table => new
                {
                    ClassId = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    ClassName = table.Column<string>(name: "Class Name", type: "nvarchar(max)", nullable: false),
                    Schedule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Teacherid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classModels", x => x.ClassId);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    FirstName = table.Column<string>(name: "First Name", type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(name: "Last Name", type: "nvarchar(max)", nullable: false),
                    dob = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sub",
                columns: table => new
                {
                    sub_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    sub_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sub", x => x.sub_Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    teacherId = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    teacherFirstName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    teacherLastName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    dateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    teacherGender = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    teacherSubjectTaught = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    teacherEmail = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    teacherPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    teacherAddress = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    teacherClass = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.teacherId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    userName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    password = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    role = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "exams",
                columns: table => new
                {
                    exam_Id = table.Column<int>(type: "int", nullable: false),
                    exam_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    examTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    class_Id = table.Column<string>(type: "varchar(30)", nullable: false),
                    sub_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exams", x => x.exam_Id);
                    table.ForeignKey(
                        name: "FK_exams_classModels_class_Id",
                        column: x => x.class_Id,
                        principalTable: "classModels",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_exams_sub_sub_id",
                        column: x => x.sub_id,
                        principalTable: "sub",
                        principalColumn: "sub_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "results",
                columns: table => new
                {
                    Res_Id = table.Column<int>(type: "int", nullable: false),
                    marks = table.Column<float>(type: "real", nullable: false),
                    exam_Id = table.Column<int>(type: "int", nullable: false),
                    stu_id = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_results", x => x.Res_Id);
                    table.ForeignKey(
                        name: "FK_results_exams_exam_Id",
                        column: x => x.exam_Id,
                        principalTable: "exams",
                        principalColumn: "exam_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_results_students_stu_id",
                        column: x => x.stu_id,
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_exams_class_Id",
                table: "exams",
                column: "class_Id");

            migrationBuilder.CreateIndex(
                name: "IX_exams_sub_id",
                table: "exams",
                column: "sub_id");

            migrationBuilder.CreateIndex(
                name: "IX_results_exam_Id",
                table: "results",
                column: "exam_Id");

            migrationBuilder.CreateIndex(
                name: "IX_results_stu_id",
                table: "results",
                column: "stu_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdmissionNoTable");

            migrationBuilder.DropTable(
                name: "results");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "exams");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "classModels");

            migrationBuilder.DropTable(
                name: "sub");
        }
    }
}
