using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditTriel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "NarratorStudents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "NarratorStudents",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "NarratorStudents",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "NarratorStudents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "NarratorStudents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "NarratorStudents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "NarratorStudents",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "NarratorStudents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "NarratorsCriticisms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "NarratorsCriticisms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "NarratorsCriticisms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "NarratorsCriticisms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "NarratorsCriticisms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "NarratorsCriticisms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "NarratorsCriticisms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "NarratorsCriticisms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "HadithTurkies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "HadithTurkies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "HadithTurkies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "HadithTurkies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "HadithTurkies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "HadithTurkies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "HadithTurkies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "HadithTurkies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "HadithSharhs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "HadithSharhs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "HadithSharhs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "HadithSharhs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "HadithSharhs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "HadithSharhs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "HadithSharhs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "HadithSharhs",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "HadithIndonicies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "HadithIndonicies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "HadithIndonicies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "HadithIndonicies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "HadithIndonicies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "HadithIndonicies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "HadithIndonicies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "HadithIndonicies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "HadithFrenshes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "HadithFrenshes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "HadithFrenshes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "HadithFrenshes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "HadithFrenshes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "HadithFrenshes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "HadithFrenshes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "HadithFrenshes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "HadithEnglishes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "HadithEnglishes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "HadithEnglishes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "HadithEnglishes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "HadithEnglishes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "HadithEnglishes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "HadithEnglishes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "HadithEnglishes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "HadithCollections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "HadithCollections",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "HadithCollections",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "HadithCollections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "HadithCollections",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "HadithCollections",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "HadithCollections",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "HadithCollections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "HadithAurdos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "HadithAurdos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "HadithAurdos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "HadithAurdos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "HadithAurdos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "HadithAurdos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "HadithAurdos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "HadithAurdos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Classifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Classifications",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Classifications",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Classifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Classifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Classifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Classifications",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Classifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Books",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Books",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Books",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Babs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Babs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Babs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Babs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Babs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Babs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Babs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Babs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "NarratorStudents");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "NarratorStudents");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "NarratorStudents");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "NarratorStudents");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "NarratorStudents");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "NarratorStudents");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "NarratorStudents");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "NarratorStudents");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "NarratorsCriticisms");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "NarratorsCriticisms");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "NarratorsCriticisms");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "NarratorsCriticisms");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "NarratorsCriticisms");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "NarratorsCriticisms");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "NarratorsCriticisms");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "NarratorsCriticisms");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "HadithTurkies");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "HadithTurkies");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "HadithTurkies");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "HadithTurkies");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "HadithTurkies");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "HadithTurkies");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "HadithTurkies");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "HadithTurkies");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "HadithSharhs");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "HadithSharhs");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "HadithSharhs");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "HadithSharhs");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "HadithSharhs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "HadithSharhs");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "HadithSharhs");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "HadithSharhs");

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

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "HadithIndonicies");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "HadithIndonicies");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "HadithIndonicies");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "HadithIndonicies");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "HadithIndonicies");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "HadithIndonicies");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "HadithIndonicies");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "HadithIndonicies");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "HadithFrenshes");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "HadithFrenshes");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "HadithFrenshes");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "HadithFrenshes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "HadithFrenshes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "HadithFrenshes");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "HadithFrenshes");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "HadithFrenshes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "HadithEnglishes");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "HadithEnglishes");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "HadithEnglishes");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "HadithEnglishes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "HadithEnglishes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "HadithEnglishes");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "HadithEnglishes");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "HadithEnglishes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "HadithCollections");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "HadithCollections");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "HadithCollections");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "HadithCollections");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "HadithCollections");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "HadithCollections");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "HadithCollections");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "HadithCollections");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "HadithAurdos");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "HadithAurdos");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "HadithAurdos");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "HadithAurdos");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "HadithAurdos");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "HadithAurdos");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "HadithAurdos");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "HadithAurdos");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Classifications");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Classifications");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Classifications");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Classifications");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Classifications");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Classifications");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Classifications");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Classifications");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Babs");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Babs");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Babs");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Babs");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Babs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Babs");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Babs");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Babs");
        }
    }
}
