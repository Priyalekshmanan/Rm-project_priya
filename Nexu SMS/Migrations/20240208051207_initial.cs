using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nexu_SMS.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
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
                name: "students",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    FirstName = table.Column<string>(name: "First Name", type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(name: "Last Name", type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(name: "E-mail", type: "nvarchar(max)", nullable: false),
                    MobileNo = table.Column<string>(name: "Mobile No", type: "nvarchar(max)", nullable: false),
                    dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class = table.Column<int>(type: "int", nullable: false),
                    Section = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "subjects",
                columns: table => new
                {
                    SubjectId = table.Column<string>(name: "Subject Id", type: "nvarchar(450)", nullable: false),
                    SubjectName = table.Column<string>(name: "Subject Name", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjects", x => x.SubjectId);
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
                name: "Student_Attendance_Table",
                columns: table => new
                {
                    attendanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    studentId = table.Column<string>(type: "varchar(30)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_Attendance_Table", x => x.attendanceId);
                    table.ForeignKey(
                        name: "FK_Student_Attendance_Table_students_studentId",
                        column: x => x.studentId,
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Class_Table",
                columns: table => new
                {
                    ClassId = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    ClassName = table.Column<string>(name: "Class Name", type: "nvarchar(max)", nullable: false),
                    TeacherID = table.Column<string>(name: "Teacher ID", type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class_Table", x => x.ClassId);
                    table.ForeignKey(
                        name: "FK_Class_Table_Teachers_Teacher ID",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "teacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teacher_Attendance_Table",
                columns: table => new
                {
                    attendanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    teacherId = table.Column<string>(type: "varchar(30)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher_Attendance_Table", x => x.attendanceId);
                    table.ForeignKey(
                        name: "FK_Teacher_Attendance_Table_Teachers_teacherId",
                        column: x => x.teacherId,
                        principalTable: "Teachers",
                        principalColumn: "teacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "exams",
                columns: table => new
                {
                    ExamID = table.Column<string>(name: "Exam ID", type: "nvarchar(450)", nullable: false),
                    ExamName = table.Column<string>(name: "Exam Name", type: "nvarchar(max)", nullable: false),
                    ExamTime = table.Column<string>(name: "Exam Time", type: "nvarchar(max)", nullable: false),
                    ExamDate = table.Column<DateTime>(name: "Exam Date", type: "datetime2", nullable: false),
                    ClassID = table.Column<string>(name: "Class ID", type: "varchar(30)", nullable: false),
                    SubjectID = table.Column<string>(name: "Subject ID", type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exams", x => x.ExamID);
                    table.ForeignKey(
                        name: "FK_exams_Class_Table_Class ID",
                        column: x => x.ClassID,
                        principalTable: "Class_Table",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_exams_subjects_Subject ID",
                        column: x => x.SubjectID,
                        principalTable: "subjects",
                        principalColumn: "Subject Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "results",
                columns: table => new
                {
                    ResultID = table.Column<string>(name: "Result ID", type: "nvarchar(450)", nullable: false),
                    ExamID = table.Column<string>(name: "Exam ID", type: "nvarchar(450)", nullable: false),
                    StudentID = table.Column<string>(name: "Student ID", type: "varchar(30)", nullable: false),
                    SubjectID = table.Column<string>(name: "Subject ID", type: "nvarchar(450)", nullable: false),
                    Marks = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_results", x => x.ResultID);
                    table.ForeignKey(
                        name: "FK_results_exams_Exam ID",
                        column: x => x.ExamID,
                        principalTable: "exams",
                        principalColumn: "Exam ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_results_students_Student ID",
                        column: x => x.StudentID,
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_results_subjects_Subject ID",
                        column: x => x.SubjectID,
                        principalTable: "subjects",
                        principalColumn: "Subject Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Class_Table_Teacher ID",
                table: "Class_Table",
                column: "Teacher ID");

            migrationBuilder.CreateIndex(
                name: "IX_exams_Class ID",
                table: "exams",
                column: "Class ID");

            migrationBuilder.CreateIndex(
                name: "IX_exams_Subject ID",
                table: "exams",
                column: "Subject ID");

            migrationBuilder.CreateIndex(
                name: "IX_results_Exam ID",
                table: "results",
                column: "Exam ID");

            migrationBuilder.CreateIndex(
                name: "IX_results_Student ID",
                table: "results",
                column: "Student ID");

            migrationBuilder.CreateIndex(
                name: "IX_results_Subject ID",
                table: "results",
                column: "Subject ID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Attendance_Table_studentId",
                table: "Student_Attendance_Table",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_Attendance_Table_teacherId",
                table: "Teacher_Attendance_Table",
                column: "teacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdmissionNoTable");

            migrationBuilder.DropTable(
                name: "results");

            migrationBuilder.DropTable(
                name: "Student_Attendance_Table");

            migrationBuilder.DropTable(
                name: "Teacher_Attendance_Table");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "exams");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "Class_Table");

            migrationBuilder.DropTable(
                name: "subjects");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
