using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationShipSharhBookAndHadithSharh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookName",
                table: "HadithSharhs");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "HadithSharhs",
                newName: "BookSharhId");

            migrationBuilder.CreateIndex(
                name: "IX_HadithSharhs_BookSharhId",
                table: "HadithSharhs",
                column: "BookSharhId");

            migrationBuilder.AddForeignKey(
                name: "FK_HadithSharhs_SharhBooks_BookSharhId",
                table: "HadithSharhs",
                column: "BookSharhId",
                principalTable: "SharhBooks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HadithSharhs_SharhBooks_BookSharhId",
                table: "HadithSharhs");

            migrationBuilder.DropIndex(
                name: "IX_HadithSharhs_BookSharhId",
                table: "HadithSharhs");

            migrationBuilder.RenameColumn(
                name: "BookSharhId",
                table: "HadithSharhs",
                newName: "BookId");

            migrationBuilder.AddColumn<string>(
                name: "BookName",
                table: "HadithSharhs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
