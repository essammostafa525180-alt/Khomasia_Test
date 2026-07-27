using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class alterHadithSharhMissingAndHadithSharhTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Hid",
                table: "HadithSharhs",
                newName: "HadithNumber");

            migrationBuilder.RenameColumn(
                name: "HNumber",
                table: "hadithSharhMissings",
                newName: "HadithNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HadithNumber",
                table: "HadithSharhs",
                newName: "Hid");

            migrationBuilder.RenameColumn(
                name: "HadithNumber",
                table: "hadithSharhMissings",
                newName: "HNumber");
        }
    }
}
