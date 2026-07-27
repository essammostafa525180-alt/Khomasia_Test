using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterHadithTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Hadiths");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Hadiths");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Hadiths");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Hadiths");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Hadiths");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Hadiths");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Hadiths");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Hadiths");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Hadiths");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Hadiths",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Hadiths",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Hadiths",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Hadiths",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Hadiths",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Hadiths",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Hadiths",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Hadiths",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Hadiths",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
