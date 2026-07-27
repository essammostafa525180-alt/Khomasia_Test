using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationShipClassificationAndBookSharh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SharhBooks_Classifications_ClassificationId",
                table: "SharhBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_SharhBooks_Classifications_ClassificationRefrenaceId",
                table: "SharhBooks");

            migrationBuilder.AddForeignKey(
                name: "FK_SharhBooks_Classifications_ClassificationId",
                table: "SharhBooks",
                column: "ClassificationId",
                principalTable: "Classifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SharhBooks_Classifications_ClassificationRefrenaceId",
                table: "SharhBooks",
                column: "ClassificationRefrenaceId",
                principalTable: "Classifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SharhBooks_Classifications_ClassificationId",
                table: "SharhBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_SharhBooks_Classifications_ClassificationRefrenaceId",
                table: "SharhBooks");

            migrationBuilder.AddForeignKey(
                name: "FK_SharhBooks_Classifications_ClassificationId",
                table: "SharhBooks",
                column: "ClassificationId",
                principalTable: "Classifications",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SharhBooks_Classifications_ClassificationRefrenaceId",
                table: "SharhBooks",
                column: "ClassificationRefrenaceId",
                principalTable: "Classifications",
                principalColumn: "Id");
        }
    }
}
