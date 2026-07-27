using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class alterTableHadithTakhreej1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HadithTakhreejs",
                table: "HadithTakhreejs");

            migrationBuilder.DropIndex(
                name: "IX_HadithTakhreejs_HadithIdFrom",
                table: "HadithTakhreejs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HadithTakhreejs",
                table: "HadithTakhreejs",
                columns: new[] { "HadithIdFrom", "HadithIdTo" });

            migrationBuilder.CreateIndex(
                name: "IX_HadithTakhreejs_HadithIdTo",
                table: "HadithTakhreejs",
                column: "HadithIdTo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HadithTakhreejs",
                table: "HadithTakhreejs");

            migrationBuilder.DropIndex(
                name: "IX_HadithTakhreejs_HadithIdTo",
                table: "HadithTakhreejs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HadithTakhreejs",
                table: "HadithTakhreejs",
                columns: new[] { "HadithIdTo", "HadithIdFrom" });

            migrationBuilder.CreateIndex(
                name: "IX_HadithTakhreejs_HadithIdFrom",
                table: "HadithTakhreejs",
                column: "HadithIdFrom");
        }
    }
}
