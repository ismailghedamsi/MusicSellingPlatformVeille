using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicSellingApp.Server.Migrations
{
    public partial class onetomanyartistalbums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_TrackLists_TrackListId",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_TrackListId",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "TrackListId",
                table: "Albums");

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "Albums",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "ArtistId1",
                table: "Albums",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArtistId1",
                table: "Albums",
                column: "ArtistId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Artists_ArtistId1",
                table: "Albums",
                column: "ArtistId1",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Artists_ArtistId1",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_ArtistId1",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "ArtistId1",
                table: "Albums");

            migrationBuilder.AddColumn<int>(
                name: "TrackListId",
                table: "Albums",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Albums_TrackListId",
                table: "Albums",
                column: "TrackListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_TrackLists_TrackListId",
                table: "Albums",
                column: "TrackListId",
                principalTable: "TrackLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
