using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class renameTableTeacherToNarratorTeacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.RenameTable(
                name: "Teachers",
                newName: "NarratorTeachers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NarratorTeachers",
                table: "NarratorTeachers",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NarratorTeachers",
                table: "NarratorTeachers");

            migrationBuilder.RenameTable(
                name: "NarratorTeachers",
                newName: "Teachers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "Id");
        }
    }
}
