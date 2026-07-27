using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class alterHadithSharhMissingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Hid",
                table: "hadithSharhMissings",
                newName: "HNumber");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "hadithSharhMissings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "hadithSharhMissings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "hadithSharhMissings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "hadithSharhMissings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "hadithSharhMissings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "hadithSharhMissings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "hadithSharhMissings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "hadithSharhMissings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "hadithSharhMissings");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "hadithSharhMissings");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "hadithSharhMissings");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "hadithSharhMissings");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "hadithSharhMissings");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "hadithSharhMissings");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "hadithSharhMissings");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "hadithSharhMissings");

            migrationBuilder.RenameColumn(
                name: "HNumber",
                table: "hadithSharhMissings",
                newName: "Hid");
        }
    }
}
