using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class alterSharhBookTable5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SharhBooks_ClassificationRefrenaceId",
                table: "SharhBooks",
                column: "ClassificationRefrenaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_SharhBooks_Classifications_ClassificationRefrenaceId",
                table: "SharhBooks",
                column: "ClassificationRefrenaceId",
                principalTable: "Classifications",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SharhBooks_Classifications_ClassificationRefrenaceId",
                table: "SharhBooks");

            migrationBuilder.DropIndex(
                name: "IX_SharhBooks_ClassificationRefrenaceId",
                table: "SharhBooks");
        }
    }
}
