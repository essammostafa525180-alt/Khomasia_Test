using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class alterSharhBookTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClassificationIdNew",
                table: "SharhBooks",
                newName: "ClassificationRefrenaceId");

            migrationBuilder.AlterColumn<int>(
                name: "Selid",
                table: "HadithTranslations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClassificationRefrenaceId",
                table: "SharhBooks",
                newName: "ClassificationIdNew");

            migrationBuilder.AlterColumn<int>(
                name: "Selid",
                table: "HadithTranslations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
