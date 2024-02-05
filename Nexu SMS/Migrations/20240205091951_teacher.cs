using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nexu_SMS.Migrations
{
    /// <inheritdoc />
    public partial class teacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "classModels");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
