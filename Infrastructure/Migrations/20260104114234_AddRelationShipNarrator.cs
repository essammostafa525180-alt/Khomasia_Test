using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationShipNarrator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "NarratorTeachers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "NarratorTeachers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "NarratorTeachers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "NarratorTeachers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "NarratorTeachers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "NarratorTeachers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "NarratorTeachers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "NarratorTeachers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Narrators",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Narrators",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Narrators",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Narrators",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Narrators",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Narrators",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Narrators",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Narrators",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NarratorTeachers_NarratorId",
                table: "NarratorTeachers",
                column: "NarratorId");

            migrationBuilder.CreateIndex(
                name: "IX_NarratorStudents_NarratorId",
                table: "NarratorStudents",
                column: "NarratorId");

            migrationBuilder.CreateIndex(
                name: "IX_NarratorsCriticisms_NarratorId",
                table: "NarratorsCriticisms",
                column: "NarratorId");

            migrationBuilder.AddForeignKey(
                name: "FK_NarratorsCriticisms_Narrators_NarratorId",
                table: "NarratorsCriticisms",
                column: "NarratorId",
                principalTable: "Narrators",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NarratorStudents_Narrators_NarratorId",
                table: "NarratorStudents",
                column: "NarratorId",
                principalTable: "Narrators",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NarratorTeachers_Narrators_NarratorId",
                table: "NarratorTeachers",
                column: "NarratorId",
                principalTable: "Narrators",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NarratorsCriticisms_Narrators_NarratorId",
                table: "NarratorsCriticisms");

            migrationBuilder.DropForeignKey(
                name: "FK_NarratorStudents_Narrators_NarratorId",
                table: "NarratorStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_NarratorTeachers_Narrators_NarratorId",
                table: "NarratorTeachers");

            migrationBuilder.DropIndex(
                name: "IX_NarratorTeachers_NarratorId",
                table: "NarratorTeachers");

            migrationBuilder.DropIndex(
                name: "IX_NarratorStudents_NarratorId",
                table: "NarratorStudents");

            migrationBuilder.DropIndex(
                name: "IX_NarratorsCriticisms_NarratorId",
                table: "NarratorsCriticisms");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "NarratorTeachers");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "NarratorTeachers");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "NarratorTeachers");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "NarratorTeachers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "NarratorTeachers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "NarratorTeachers");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "NarratorTeachers");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "NarratorTeachers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Narrators");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Narrators");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Narrators");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Narrators");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Narrators");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Narrators");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Narrators");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Narrators");
        }
    }
}
