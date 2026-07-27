using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationShipHadithAndTakhreej2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_HadithTakhreejs_Hid",
                table: "HadithTakhreejs",
                column: "Hid");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_HadithTakhreejs_Hadiths_Hid",
            //    table: "HadithTakhreejs",
            //    column: "Hid",
            //    principalTable: "Hadiths",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_HadithTakhreejs_Hadiths_Selid",
            //    table: "HadithTakhreejs",
            //    column: "Selid",
            //    principalTable: "Hadiths",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HadithTakhreejs_Hadiths_Hid",
                table: "HadithTakhreejs");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_HadithTakhreejs_Hadiths_Selid",
            //    table: "HadithTakhreejs");

            //migrationBuilder.DropIndex(
            //    name: "IX_HadithTakhreejs_Hid",
            //    table: "HadithTakhreejs");
        }
    }
}
