using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NarratorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Narrators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteId = table.Column<int>(type: "int", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kunya = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nasab = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Madhhab = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Layer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeathYear = table.Column<int>(type: "int", nullable: true),
                    BirthYear = table.Column<int>(type: "int", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Residence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeathPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Relatives = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mawali = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NarratedFor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kamal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SirAlamAlNubala = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SifatAlSafwa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narrators", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Narrators");
        }
    }
}
