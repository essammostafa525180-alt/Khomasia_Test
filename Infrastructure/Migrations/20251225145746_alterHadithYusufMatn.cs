using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class alterHadithYusufMatn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //    migrationBuilder.DropForeignKey(
            //        name: "FK_Hadiths_Babs_BabId",
            //        table: "Hadiths");

            //    migrationBuilder.DropIndex(
            //        name: "IX_Hadiths_BabId",
            //        table: "Hadiths");

            //    migrationBuilder.DropColumn(
            //        name: "BabId",
            //        table: "Hadiths");

            migrationBuilder.RenameColumn(
                name: "YusufMatn",
                table: "Hadiths",
                newName: "Matn");

            migrationBuilder.CreateIndex(
                name: "IX_Hadiths_NewBabId",
                table: "Hadiths",
                column: "NewBabId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hadiths_Babs_NewBabId",
                table: "Hadiths",
                column: "NewBabId",
                principalTable: "Babs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hadiths_Babs_NewBabId",
                table: "Hadiths");

            migrationBuilder.DropIndex(
                name: "IX_Hadiths_NewBabId",
                table: "Hadiths");

            migrationBuilder.RenameColumn(
                name: "Matn",
                table: "Hadiths",
                newName: "YusufMatn");

            //migrationBuilder.AddColumn<int>(
            //    name: "BabId",
            //    table: "Hadiths",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Hadiths_BabId",
            //    table: "Hadiths",
            //    column: "BabId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Hadiths_Babs_BabId",
            //    table: "Hadiths",
            //    column: "BabId",
            //    principalTable: "Babs",
            //    principalColumn: "Id");
        }
    }
}
