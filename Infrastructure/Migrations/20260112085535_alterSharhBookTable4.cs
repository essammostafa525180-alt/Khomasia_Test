using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class alterSharhBookTable4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookId",
                table: "SharhBooks");

            migrationBuilder.CreateIndex(
                name: "IX_SharhBooks_ClassificationId",
                table: "SharhBooks",
                column: "ClassificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_SharhBooks_Classifications_ClassificationId",
                table: "SharhBooks",
                column: "ClassificationId",
                principalTable: "Classifications",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SharhBooks_Classifications_ClassificationId",
                table: "SharhBooks");

            migrationBuilder.DropIndex(
                name: "IX_SharhBooks_ClassificationId",
                table: "SharhBooks");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "SharhBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
