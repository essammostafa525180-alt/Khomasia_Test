using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterTablehadithMissing3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NewBabId",
                table: "HadithMissings",
                newName: "BabId");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "HadithMissings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "HadithMissings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "HadithMissings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "HadithMissings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "HadithMissings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "HadithMissings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "HadithMissings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "HadithMissings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "HadithMissings");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "HadithMissings");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "HadithMissings");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "HadithMissings");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "HadithMissings");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "HadithMissings");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "HadithMissings");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "HadithMissings");

            migrationBuilder.RenameColumn(
                name: "BabId",
                table: "HadithMissings",
                newName: "NewBabId");
        }
    }
}
