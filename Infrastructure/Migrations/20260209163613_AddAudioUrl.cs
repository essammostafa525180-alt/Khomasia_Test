using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAudioUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HavingMp3",
                table: "Hadiths",
                newName: "HasAudio");

            migrationBuilder.AddColumn<string>(
                name: "AudioUrl",
                table: "Hadiths",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AudioUrl",
                table: "Hadiths");

            migrationBuilder.RenameColumn(
                name: "HasAudio",
                table: "Hadiths",
                newName: "HavingMp3");
        }
    }
}
