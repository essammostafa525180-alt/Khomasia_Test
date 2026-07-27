using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class alterHadithSharhMissingAndHadithSharhTable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Selid",
                table: "HadithSharhs",
                newName: "HadithId");

            migrationBuilder.RenameColumn(
                name: "Selid",
                table: "hadithSharhMissings",
                newName: "HadithId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HadithId",
                table: "HadithSharhs",
                newName: "Selid");

            migrationBuilder.RenameColumn(
                name: "HadithId",
                table: "hadithSharhMissings",
                newName: "Selid");
        }
    }
}
