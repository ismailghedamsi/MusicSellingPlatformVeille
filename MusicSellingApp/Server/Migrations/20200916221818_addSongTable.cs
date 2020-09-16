using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicSellingApp.Server.Migrations
{
    public partial class addSongTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Song_TrackLists_TrackListId",
                table: "Song");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Song",
                table: "Song");

            migrationBuilder.RenameTable(
                name: "Song",
                newName: "Songs");

            migrationBuilder.RenameIndex(
                name: "IX_Song_TrackListId",
                table: "Songs",
                newName: "IX_Songs_TrackListId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Songs",
                table: "Songs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_TrackLists_TrackListId",
                table: "Songs",
                column: "TrackListId",
                principalTable: "TrackLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_TrackLists_TrackListId",
                table: "Songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Songs",
                table: "Songs");

            migrationBuilder.RenameTable(
                name: "Songs",
                newName: "Song");

            migrationBuilder.RenameIndex(
                name: "IX_Songs_TrackListId",
                table: "Song",
                newName: "IX_Song_TrackListId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Song",
                table: "Song",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Song_TrackLists_TrackListId",
                table: "Song",
                column: "TrackListId",
                principalTable: "TrackLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
