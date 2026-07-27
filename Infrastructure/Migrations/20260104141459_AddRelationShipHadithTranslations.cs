using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationShipHadithTranslations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_HadithTranslations_LanguageId",
                table: "HadithTranslations",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_HadithTranslations_HadithLanguages_LanguageId",
                table: "HadithTranslations",
                column: "LanguageId",
                principalTable: "HadithLanguages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HadithTranslations_HadithLanguages_LanguageId",
                table: "HadithTranslations");

            migrationBuilder.DropIndex(
                name: "IX_HadithTranslations_LanguageId",
                table: "HadithTranslations");
        }
    }
}
