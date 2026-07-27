using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterContactMessagesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ContactMessages");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ContactMessages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "ContactMessages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "ContactMessages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "ContactMessages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ContactMessages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ContactMessages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "ContactMessages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ContactMessages",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ContactMessages");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "ContactMessages");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "ContactMessages");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "ContactMessages");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ContactMessages");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ContactMessages");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "ContactMessages");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ContactMessages");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ContactMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
