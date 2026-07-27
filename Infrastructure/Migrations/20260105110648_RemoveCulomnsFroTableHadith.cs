using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCulomnsFroTableHadith : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastViews",
                table: "Hadiths");

            migrationBuilder.DropColumn(
                name: "OldBabId",
                table: "Hadiths");

            migrationBuilder.DropColumn(
                name: "OldCatId",
                table: "Hadiths");

            migrationBuilder.DropColumn(
                name: "OldChapterId",
                table: "Hadiths");

            migrationBuilder.DropColumn(
                name: "OldHadithId",
                table: "Hadiths");

            migrationBuilder.DropColumn(
                name: "View",
                table: "Hadiths");

            migrationBuilder.DropColumn(
                name: "WordCount",
                table: "Hadiths");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastViews",
                table: "Hadiths",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OldBabId",
                table: "Hadiths",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OldCatId",
                table: "Hadiths",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OldChapterId",
                table: "Hadiths",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OldHadithId",
                table: "Hadiths",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "View",
                table: "Hadiths",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WordCount",
                table: "Hadiths",
                type: "int",
                nullable: true);
        }
    }
}
