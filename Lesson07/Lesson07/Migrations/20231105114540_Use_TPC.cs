using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lesson07.Migrations
{
    /// <inheritdoc />
    public partial class Use_TPC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Person_Id",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_FullTimeStudent_Student_Id",
                table: "FullTimeStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_PartTimeStudent_Student_Id",
                table: "PartTimeStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_Security_Employee_Id",
                table: "Security");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Person_Id",
                table: "Teacher");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Security",
                table: "Security");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PartTimeStudent",
                table: "PartTimeStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FullTimeStudent",
                table: "FullTimeStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "Teacher",
                newName: "Teachers");

            migrationBuilder.RenameTable(
                name: "Security",
                newName: "Securities");

            migrationBuilder.RenameTable(
                name: "PartTimeStudent",
                newName: "PartTimeStudents");

            migrationBuilder.RenameTable(
                name: "FullTimeStudent",
                newName: "FullTimeStudents");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.CreateSequence(
                name: "PersonSequence");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR [PersonSequence]",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthdate",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Securities",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR [PersonSequence]",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Securities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthdate",
                table: "Securities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Securities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Hiredate",
                table: "Securities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Securities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Securities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "Securities",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PartTimeStudents",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR [PersonSequence]",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "PartTimeStudents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "AverageGrade",
                table: "PartTimeStudents",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthdate",
                table: "PartTimeStudents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "PartTimeStudents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "PartTimeStudents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "PartTimeStudents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Semester",
                table: "PartTimeStudents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "PartTimeStudents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "FullTimeStudents",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR [PersonSequence]",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "FullTimeStudents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "AverageGrade",
                table: "FullTimeStudents",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthdate",
                table: "FullTimeStudents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "FullTimeStudents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "FullTimeStudents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "FullTimeStudents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Semester",
                table: "FullTimeStudents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "FullTimeStudents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR [PersonSequence]",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthdate",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Securities",
                table: "Securities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PartTimeStudents",
                table: "PartTimeStudents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FullTimeStudents",
                table: "FullTimeStudents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Securities",
                table: "Securities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PartTimeStudents",
                table: "PartTimeStudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FullTimeStudents",
                table: "FullTimeStudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Securities");

            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "Securities");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Securities");

            migrationBuilder.DropColumn(
                name: "Hiredate",
                table: "Securities");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Securities");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Securities");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Securities");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "PartTimeStudents");

            migrationBuilder.DropColumn(
                name: "AverageGrade",
                table: "PartTimeStudents");

            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "PartTimeStudents");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "PartTimeStudents");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "PartTimeStudents");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "PartTimeStudents");

            migrationBuilder.DropColumn(
                name: "Semester",
                table: "PartTimeStudents");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PartTimeStudents");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "FullTimeStudents");

            migrationBuilder.DropColumn(
                name: "AverageGrade",
                table: "FullTimeStudents");

            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "FullTimeStudents");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "FullTimeStudents");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "FullTimeStudents");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "FullTimeStudents");

            migrationBuilder.DropColumn(
                name: "Semester",
                table: "FullTimeStudents");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "FullTimeStudents");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Employees");

            migrationBuilder.DropSequence(
                name: "PersonSequence");

            migrationBuilder.RenameTable(
                name: "Teachers",
                newName: "Teacher");

            migrationBuilder.RenameTable(
                name: "Securities",
                newName: "Security");

            migrationBuilder.RenameTable(
                name: "PartTimeStudents",
                newName: "PartTimeStudent");

            migrationBuilder.RenameTable(
                name: "FullTimeStudents",
                newName: "FullTimeStudent");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Teacher",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NEXT VALUE FOR [PersonSequence]");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Security",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NEXT VALUE FOR [PersonSequence]");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PartTimeStudent",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NEXT VALUE FOR [PersonSequence]");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "FullTimeStudent",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NEXT VALUE FOR [PersonSequence]");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Employee",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NEXT VALUE FOR [PersonSequence]");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Security",
                table: "Security",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PartTimeStudent",
                table: "PartTimeStudent",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FullTimeStudent",
                table: "FullTimeStudent",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
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

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Person_Id",
                table: "Employee",
                column: "Id",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FullTimeStudent_Student_Id",
                table: "FullTimeStudent",
                column: "Id",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartTimeStudent_Student_Id",
                table: "PartTimeStudent",
                column: "Id",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Security_Employee_Id",
                table: "Security",
                column: "Id",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Person_Id",
                table: "Teacher",
                column: "Id",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
