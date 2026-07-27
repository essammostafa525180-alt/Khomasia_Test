using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class alterNarratorTableSiteId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Narrators",
                table: "Narrators");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Narrators");

            migrationBuilder.AlterColumn<int>(
                name: "SiteId",
                table: "Narrators",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
            //.Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Narrators",
                table: "Narrators",
                column: "SiteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Narrators",
                table: "Narrators");

            migrationBuilder.AlterColumn<int>(
                name: "SiteId",
                table: "Narrators",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
            //.OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Narrators",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Narrators",
                table: "Narrators",
                column: "Id");
        }
    }
}
