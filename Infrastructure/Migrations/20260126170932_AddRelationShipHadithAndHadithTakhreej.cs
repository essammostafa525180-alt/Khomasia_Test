using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationShipHadithAndHadithTakhreej : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HadithTakhreejs",
                table: "HadithTakhreejs");

            migrationBuilder.DropColumn(
                name: "Selid2",
                table: "HadithTakhreejs");

            migrationBuilder.AlterColumn<int>(
                name: "Selid",
                table: "HadithTakhreejs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Hid",
                table: "HadithTakhreejs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                columns: new[] { "Selid", "Hid" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<int>(
                name: "Hid",
                table: "HadithTakhreejs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Selid",
                table: "HadithTakhreejs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Selid2",
                table: "HadithTakhreejs",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HadithTakhreejs",
                table: "HadithTakhreejs",
                column: "Id");
        }
    }
}
