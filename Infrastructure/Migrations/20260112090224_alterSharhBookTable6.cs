using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class alterSharhBookTable6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverImage",
                table: "SharhBooks");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "SharhBooks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "SharhBooks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "SharhBooks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "SharhBooks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "SharhBooks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SharhBooks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "SharhBooks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "SharhBooks",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SharhBooks");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "SharhBooks");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "SharhBooks");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "SharhBooks");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "SharhBooks");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SharhBooks");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "SharhBooks");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "SharhBooks");

            migrationBuilder.AddColumn<string>(
                name: "CoverImage",
                table: "SharhBooks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
