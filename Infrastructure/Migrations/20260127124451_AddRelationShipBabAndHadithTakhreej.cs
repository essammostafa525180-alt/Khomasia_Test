using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationShipBabAndHadithTakhreej : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BabId",
                table: "HadithTakhreejs",
                newName: "OldBabId");

            migrationBuilder.CreateIndex(
                name: "IX_HadithTakhreejs_NewBab",
                table: "HadithTakhreejs",
                column: "NewBab");

            migrationBuilder.AddForeignKey(
                name: "FK_HadithTakhreejs_Babs_NewBab",
                table: "HadithTakhreejs",
                column: "NewBab",
                principalTable: "Babs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HadithTakhreejs_Babs_NewBab",
                table: "HadithTakhreejs");

            migrationBuilder.DropIndex(
                name: "IX_HadithTakhreejs_NewBab",
                table: "HadithTakhreejs");

            migrationBuilder.RenameColumn(
                name: "OldBabId",
                table: "HadithTakhreejs",
                newName: "BabId");
        }
    }
}
