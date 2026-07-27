using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterHadithTakhreej : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HadithTakhreejs_Babs_NewBab",
                table: "HadithTakhreejs");

            migrationBuilder.RenameColumn(
                name: "NewBab",
                table: "HadithTakhreejs",
                newName: "BabId");

            migrationBuilder.RenameIndex(
                name: "IX_HadithTakhreejs_NewBab",
                table: "HadithTakhreejs",
                newName: "IX_HadithTakhreejs_BabId");

            migrationBuilder.AddForeignKey(
                name: "FK_HadithTakhreejs_Babs_BabId",
                table: "HadithTakhreejs",
                column: "BabId",
                principalTable: "Babs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HadithTakhreejs_Babs_BabId",
                table: "HadithTakhreejs");

            migrationBuilder.RenameColumn(
                name: "BabId",
                table: "HadithTakhreejs",
                newName: "NewBab");

            migrationBuilder.RenameIndex(
                name: "IX_HadithTakhreejs_BabId",
                table: "HadithTakhreejs",
                newName: "IX_HadithTakhreejs_NewBab");

            migrationBuilder.AddForeignKey(
                name: "FK_HadithTakhreejs_Babs_NewBab",
                table: "HadithTakhreejs",
                column: "NewBab",
                principalTable: "Babs",
                principalColumn: "Id");
        }
    }
}
