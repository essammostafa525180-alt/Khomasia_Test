using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterTablehadithMissing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OldBabId",
                table: "HadithMissings");

            migrationBuilder.DropColumn(
                name: "OldCatId",
                table: "HadithMissings");

            migrationBuilder.DropColumn(
                name: "OldChapterId",
                table: "HadithMissings");

            migrationBuilder.DropColumn(
                name: "OldHadithId",
                table: "HadithMissings");

            migrationBuilder.RenameColumn(
                name: "YusufTaraf",
                table: "HadithMissings",
                newName: "Taraf");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Taraf",
                table: "HadithMissings",
                newName: "YusufTaraf");

            migrationBuilder.AddColumn<int>(
                name: "OldBabId",
                table: "HadithMissings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OldCatId",
                table: "HadithMissings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OldChapterId",
                table: "HadithMissings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OldHadithId",
                table: "HadithMissings",
                type: "int",
                nullable: true);
        }
    }
}
