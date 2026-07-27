using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterHadithTable4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HidOld",
                table: "Hadiths");

            migrationBuilder.RenameColumn(
                name: "order",
                table: "Hadiths",
                newName: "HadithNumber");

            migrationBuilder.RenameColumn(
                name: "YusufTaraf",
                table: "Hadiths",
                newName: "Taraf");

            migrationBuilder.AlterColumn<bool>(
                name: "HavingMp3",
                table: "Hadiths",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Taraf",
                table: "Hadiths",
                newName: "YusufTaraf");

            migrationBuilder.RenameColumn(
                name: "HadithNumber",
                table: "Hadiths",
                newName: "order");

            migrationBuilder.AlterColumn<int>(
                name: "HavingMp3",
                table: "Hadiths",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "HidOld",
                table: "Hadiths",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
