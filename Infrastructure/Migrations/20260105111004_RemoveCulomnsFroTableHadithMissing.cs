using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCulomnsFroTableHadithMissing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastViews",
                table: "HadithMissings");

            migrationBuilder.DropColumn(
                name: "View",
                table: "HadithMissings");

            migrationBuilder.DropColumn(
                name: "WordCount",
                table: "HadithMissings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastViews",
                table: "HadithMissings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "View",
                table: "HadithMissings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WordCount",
                table: "HadithMissings",
                type: "int",
                nullable: true);
        }
    }
}
