using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class alterTableHadithTakhreej : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HadithTakhreejs_Hadiths_HidHadithID",
                table: "HadithTakhreejs");

            migrationBuilder.DropForeignKey(
                name: "FK_HadithTakhreejs_Hadiths_SelHadithId",
                table: "HadithTakhreejs");

            migrationBuilder.RenameColumn(
                name: "HidHadithID",
                table: "HadithTakhreejs",
                newName: "HadithIdFrom");

            migrationBuilder.RenameColumn(
                name: "SelHadithId",
                table: "HadithTakhreejs",
                newName: "HadithIdTo");

            migrationBuilder.RenameIndex(
                name: "IX_HadithTakhreejs_HidHadithID",
                table: "HadithTakhreejs",
                newName: "IX_HadithTakhreejs_HadithIdFrom");

            migrationBuilder.AddForeignKey(
                name: "FK_HadithTakhreejs_Hadiths_HadithIdFrom",
                table: "HadithTakhreejs",
                column: "HadithIdFrom",
                principalTable: "Hadiths",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HadithTakhreejs_Hadiths_HadithIdTo",
                table: "HadithTakhreejs",
                column: "HadithIdTo",
                principalTable: "Hadiths",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HadithTakhreejs_Hadiths_HadithIdFrom",
                table: "HadithTakhreejs");

            migrationBuilder.DropForeignKey(
                name: "FK_HadithTakhreejs_Hadiths_HadithIdTo",
                table: "HadithTakhreejs");

            migrationBuilder.RenameColumn(
                name: "HadithIdFrom",
                table: "HadithTakhreejs",
                newName: "HidHadithID");

            migrationBuilder.RenameColumn(
                name: "HadithIdTo",
                table: "HadithTakhreejs",
                newName: "SelHadithId");

            migrationBuilder.RenameIndex(
                name: "IX_HadithTakhreejs_HadithIdFrom",
                table: "HadithTakhreejs",
                newName: "IX_HadithTakhreejs_HidHadithID");

            migrationBuilder.AddForeignKey(
                name: "FK_HadithTakhreejs_Hadiths_HidHadithID",
                table: "HadithTakhreejs",
                column: "HidHadithID",
                principalTable: "Hadiths",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HadithTakhreejs_Hadiths_SelHadithId",
                table: "HadithTakhreejs",
                column: "SelHadithId",
                principalTable: "Hadiths",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
