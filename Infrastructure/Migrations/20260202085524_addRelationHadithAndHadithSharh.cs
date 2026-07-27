using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addRelationHadithAndHadithSharh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_HadithSharhs_HadithId",
                table: "HadithSharhs",
                column: "HadithId");

            migrationBuilder.AddForeignKey(
                name: "FK_HadithSharhs_Hadiths_HadithId",
                table: "HadithSharhs",
                column: "HadithId",
                principalTable: "Hadiths",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HadithSharhs_Hadiths_HadithId",
                table: "HadithSharhs");

            migrationBuilder.DropIndex(
                name: "IX_HadithSharhs_HadithId",
                table: "HadithSharhs");
        }
    }
}
