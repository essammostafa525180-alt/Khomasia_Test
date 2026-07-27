using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addMissingTableHadithTakhreej : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_HadithTakhreejs_Hadiths_Hid",
            //    table: "HadithTakhreejs");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_HadithTakhreejs_Hadiths_Selid",
            //    table: "HadithTakhreejs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HadithTakhreejs",
                table: "HadithTakhreejs");

            migrationBuilder.DropIndex(
                name: "IX_HadithTakhreejs_Hid",
                table: "HadithTakhreejs");

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

            migrationBuilder.CreateTable(
                name: "HadithTakhreejMessings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Selid = table.Column<int>(type: "int", nullable: false),
                    Hid = table.Column<int>(type: "int", nullable: false),
                    CatName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CatId = table.Column<int>(type: "int", nullable: true),
                    BabName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BabId = table.Column<int>(type: "int", nullable: true),
                    ChapterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChapterId = table.Column<int>(type: "int", nullable: true),
                    NewBab = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HadithTakhreejMessings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HadithTakhreejMessings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HadithTakhreejs",
                table: "HadithTakhreejs");

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
                columns: new[] { "Selid", "Hid" });

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
    }
}
