using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lesson03.Migrations
{
    /// <inheritdoc />
    public partial class Update_Constraint_Name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Course_Group_GroupId",
                table: "Enrollment");

            migrationBuilder.AddForeignKey(
                name: "Enrollment_Course_FK",
                table: "Enrollment",
                column: "GroupId",
                principalTable: "Course_Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Enrollment_Course_FK",
                table: "Enrollment");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Course_Group_GroupId",
                table: "Enrollment",
                column: "GroupId",
                principalTable: "Course_Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
