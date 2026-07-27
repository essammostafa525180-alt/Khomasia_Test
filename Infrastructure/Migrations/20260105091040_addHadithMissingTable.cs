using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addHadithMissingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HadithMissings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OldCatId = table.Column<int>(type: "int", nullable: true),
                    OldChapterId = table.Column<int>(type: "int", nullable: false),
                    OldBabId = table.Column<int>(type: "int", nullable: true),
                    OldHadithId = table.Column<int>(type: "int", nullable: true),
                    HadithWithSign = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HId = table.Column<int>(type: "int", nullable: false),
                    SelId = table.Column<int>(type: "int", nullable: false),
                    HadithWithNoSign = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hokm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HidOld = table.Column<int>(type: "int", nullable: false),
                    YusufTaraf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Matn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HavingMp3 = table.Column<int>(type: "int", nullable: true),
                    View = table.Column<int>(type: "int", nullable: true),
                    LastViews = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WordCount = table.Column<int>(type: "int", nullable: true),
                    RawyId = table.Column<int>(type: "int", nullable: false),
                    NewBabId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HadithMissings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HadithMissings");
        }
    }
}
