using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lesson07.Migrations
{
    /// <inheritdoc />
    public partial class Use_TPT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "AverageGrade",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Hiredate",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "HourlyRate",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Security_Smena",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Semester",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Smena",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "StudyDays",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "person_type",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "Person");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Hiredate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Person_Id",
                        column: x => x.Id,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AverageGrade = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Person_Id",
                        column: x => x.Id,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    HourlyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Experience = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teacher_Person_Id",
                        column: x => x.Id,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Smena = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Security", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Security_Employee_Id",
                        column: x => x.Id,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FullTimeStudent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Smena = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullTimeStudent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FullTimeStudent_Student_Id",
                        column: x => x.Id,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartTimeStudent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    StudyDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartTimeStudent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartTimeStudent_Student_Id",
                        column: x => x.Id,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FullTimeStudent");

            migrationBuilder.DropTable(
                name: "PartTimeStudent");

            migrationBuilder.DropTable(
                name: "Security");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "Persons");

            migrationBuilder.AddColumn<decimal>(
                name: "AverageGrade",
                table: "Persons",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Experience",
                table: "Persons",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Hiredate",
                table: "Persons",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "HourlyRate",
                table: "Persons",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "Persons",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Security_Smena",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Semester",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Smena",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudyDays",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "person_type",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");
        }
    }
}
