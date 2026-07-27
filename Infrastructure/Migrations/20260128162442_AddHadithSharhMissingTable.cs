using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddHadithSharhMissingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hadithSharhMissings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hid = table.Column<int>(type: "int", nullable: false),
                    BabId = table.Column<int>(type: "int", nullable: true),
                    BookSharhId = table.Column<int>(type: "int", nullable: true),
                    SharhWithSign = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SharhWithNoSign = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Selid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hadithSharhMissings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hadithSharhMissings_SharhBooks_BookSharhId",
                        column: x => x.BookSharhId,
                        principalTable: "SharhBooks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_hadithSharhMissings_BookSharhId",
                table: "hadithSharhMissings",
                column: "BookSharhId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hadithSharhMissings");
        }
    }
}
