using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class alterHadithTakhreejRemoveOtherColum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BabName",
                table: "HadithTakhreejs");

            migrationBuilder.DropColumn(
                name: "CatId",
                table: "HadithTakhreejs");

            migrationBuilder.DropColumn(
                name: "CatName",
                table: "HadithTakhreejs");

            migrationBuilder.DropColumn(
                name: "ChapterId",
                table: "HadithTakhreejs");

            migrationBuilder.DropColumn(
                name: "ChapterName",
                table: "HadithTakhreejs");

            migrationBuilder.DropColumn(
                name: "OldBabId",
                table: "HadithTakhreejs");

            migrationBuilder.DropColumn(
                name: "BabId",
                table: "HadithTakhreejMessings");

            migrationBuilder.DropColumn(
                name: "BabName",
                table: "HadithTakhreejMessings");

            migrationBuilder.DropColumn(
                name: "CatId",
                table: "HadithTakhreejMessings");

            migrationBuilder.DropColumn(
                name: "CatName",
                table: "HadithTakhreejMessings");

            migrationBuilder.DropColumn(
                name: "ChapterId",
                table: "HadithTakhreejMessings");

            migrationBuilder.DropColumn(
                name: "ChapterName",
                table: "HadithTakhreejMessings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BabName",
                table: "HadithTakhreejs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CatId",
                table: "HadithTakhreejs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CatName",
                table: "HadithTakhreejs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChapterId",
                table: "HadithTakhreejs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChapterName",
                table: "HadithTakhreejs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OldBabId",
                table: "HadithTakhreejs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BabId",
                table: "HadithTakhreejMessings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BabName",
                table: "HadithTakhreejMessings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CatId",
                table: "HadithTakhreejMessings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CatName",
                table: "HadithTakhreejMessings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChapterId",
                table: "HadithTakhreejMessings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChapterName",
                table: "HadithTakhreejMessings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
