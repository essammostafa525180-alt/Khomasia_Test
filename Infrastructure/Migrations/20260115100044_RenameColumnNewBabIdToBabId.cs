using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumnNewBabIdToBabId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hadiths_Babs_NewBabId",
                table: "Hadiths");

            migrationBuilder.RenameColumn(
                name: "NewBabId",
                table: "Hadiths",
                newName: "BabId");

            migrationBuilder.RenameIndex(
                name: "IX_Hadiths_NewBabId",
                table: "Hadiths",
                newName: "IX_Hadiths_BabId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hadiths_Babs_BabId",
                table: "Hadiths",
                column: "BabId",
                principalTable: "Babs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hadiths_Babs_BabId",
                table: "Hadiths");

            migrationBuilder.RenameColumn(
                name: "BabId",
                table: "Hadiths",
                newName: "NewBabId");

            migrationBuilder.RenameIndex(
                name: "IX_Hadiths_BabId",
                table: "Hadiths",
                newName: "IX_Hadiths_NewBabId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hadiths_Babs_NewBabId",
                table: "Hadiths",
                column: "NewBabId",
                principalTable: "Babs",
                principalColumn: "Id");
        }
    }
}
