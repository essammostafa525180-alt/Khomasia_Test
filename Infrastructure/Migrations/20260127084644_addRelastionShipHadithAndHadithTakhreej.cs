using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addRelastionShipHadithAndHadithTakhreej : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HadithTakhreejs",
                table: "HadithTakhreejs");

            migrationBuilder.RenameColumn(
                name: "Selid",
                table: "HadithTakhreejs",
                newName: "HidHadithID");

            migrationBuilder.RenameColumn(
                name: "Hid",
                table: "HadithTakhreejs",
                newName: "SelHadithId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "HadithTakhreejs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
            //.OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HadithTakhreejs",
                table: "HadithTakhreejs",
                columns: new[] { "SelHadithId", "HidHadithID" });

            migrationBuilder.CreateIndex(
                name: "IX_HadithTakhreejs_HidHadithID",
                table: "HadithTakhreejs",
                column: "HidHadithID");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HadithTakhreejs_Hadiths_HidHadithID",
                table: "HadithTakhreejs");

            migrationBuilder.DropForeignKey(
                name: "FK_HadithTakhreejs_Hadiths_SelHadithId",
                table: "HadithTakhreejs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HadithTakhreejs",
                table: "HadithTakhreejs");

            migrationBuilder.DropIndex(
                name: "IX_HadithTakhreejs_HidHadithID",
                table: "HadithTakhreejs");

            migrationBuilder.RenameColumn(
                name: "HidHadithID",
                table: "HadithTakhreejs",
                newName: "Selid");

            migrationBuilder.RenameColumn(
                name: "SelHadithId",
                table: "HadithTakhreejs",
                newName: "Hid");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "HadithTakhreejs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
            //.Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HadithTakhreejs",
                table: "HadithTakhreejs",
                column: "Id");
        }
    }
}
