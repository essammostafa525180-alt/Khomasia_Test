using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditTriel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "HadithTakhreejs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "HadithTakhreejs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "HadithTakhreejs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "HadithTakhreejs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "HadithTakhreejs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "HadithTakhreejs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "HadithTakhreejs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "HadithTakhreejs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "HadithTakhreejs");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "HadithTakhreejs");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "HadithTakhreejs");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "HadithTakhreejs");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "HadithTakhreejs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "HadithTakhreejs");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "HadithTakhreejs");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "HadithTakhreejs");
        }
    }
}
