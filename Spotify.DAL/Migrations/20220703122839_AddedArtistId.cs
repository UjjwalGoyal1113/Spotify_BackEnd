using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spotify.DAL.Migrations
{
    public partial class AddedArtistId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ArtistId",
                table: "Ratings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ArtistId",
                table: "Ratings",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Artists_ArtistId",
                table: "Ratings",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Artists_ArtistId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_ArtistId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Ratings");
        }
    }
}
