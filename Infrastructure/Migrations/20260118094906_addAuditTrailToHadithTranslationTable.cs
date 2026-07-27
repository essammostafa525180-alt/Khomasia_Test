using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addAuditTrailToHadithTranslationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "HadithTranslations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "HadithTranslations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "HadithTranslations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "HadithTranslations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "HadithTranslations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "HadithTranslations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "HadithTranslations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "HadithTranslations",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "HadithTranslations");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "HadithTranslations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "HadithTranslations");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "HadithTranslations");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "HadithTranslations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "HadithTranslations");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "HadithTranslations");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "HadithTranslations");
        }
    }
}
