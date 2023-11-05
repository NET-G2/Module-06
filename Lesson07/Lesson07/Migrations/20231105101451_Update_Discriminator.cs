using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lesson07.Migrations
{
    /// <inheritdoc />
    public partial class Update_Discriminator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Discriminator",
                table: "Persons",
                newName: "person_type");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "person_type",
                table: "Persons",
                newName: "Discriminator");
        }
    }
}
