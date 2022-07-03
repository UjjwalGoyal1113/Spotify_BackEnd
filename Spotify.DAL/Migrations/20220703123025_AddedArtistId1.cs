using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spotify.DAL.Migrations
{
    public partial class AddedArtistId1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Artists_ArtistId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_ArtistId",
                table: "Ratings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
