using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationShipHadithAndHadithTranslation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Selid",
                table: "HadithTranslations",
                newName: "HadithId");

            migrationBuilder.RenameColumn(
                name: "Hid",
                table: "HadithTranslations",
                newName: "HadithNubmer");

            migrationBuilder.CreateIndex(
                name: "IX_HadithTranslations_HadithId",
                table: "HadithTranslations",
                column: "HadithId");

            migrationBuilder.AddForeignKey(
                name: "FK_HadithTranslations_Hadiths_HadithId",
                table: "HadithTranslations",
                column: "HadithId",
                principalTable: "Hadiths",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HadithTranslations_Hadiths_HadithId",
                table: "HadithTranslations");

            migrationBuilder.DropIndex(
                name: "IX_HadithTranslations_HadithId",
                table: "HadithTranslations");

            migrationBuilder.RenameColumn(
                name: "HadithNubmer",
                table: "HadithTranslations",
                newName: "Hid");

            migrationBuilder.RenameColumn(
                name: "HadithId",
                table: "HadithTranslations",
                newName: "Selid");
        }
    }
}
