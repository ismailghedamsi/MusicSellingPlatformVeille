using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicSellingApp.Server.Migrations
{
    public partial class AlbumTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Users_ArtistId",
                table: "Album");

            migrationBuilder.DropForeignKey(
                name: "FK_Album_Users_FanId",
                table: "Album");

            migrationBuilder.DropForeignKey(
                name: "FK_Album_TrackList_TrackListId",
                table: "Album");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Album",
                table: "Album");

            migrationBuilder.RenameTable(
                name: "Album",
                newName: "Albums");

            migrationBuilder.RenameIndex(
                name: "IX_Album_TrackListId",
                table: "Albums",
                newName: "IX_Albums_TrackListId");

            migrationBuilder.RenameIndex(
                name: "IX_Album_FanId",
                table: "Albums",
                newName: "IX_Albums_FanId");

            migrationBuilder.RenameIndex(
                name: "IX_Album_ArtistId",
                table: "Albums",
                newName: "IX_Albums_ArtistId");

            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                table: "Albums",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Albums",
                table: "Albums",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Users_ArtistId",
                table: "Albums",
                column: "ArtistId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Users_FanId",
                table: "Albums",
                column: "FanId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_TrackList_TrackListId",
                table: "Albums",
                column: "TrackListId",
                principalTable: "TrackList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Users_ArtistId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Users_FanId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Albums_TrackList_TrackListId",
                table: "Albums");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Albums",
                table: "Albums");

            migrationBuilder.RenameTable(
                name: "Albums",
                newName: "Album");

            migrationBuilder.RenameIndex(
                name: "IX_Albums_TrackListId",
                table: "Album",
                newName: "IX_Album_TrackListId");

            migrationBuilder.RenameIndex(
                name: "IX_Albums_FanId",
                table: "Album",
                newName: "IX_Album_FanId");

            migrationBuilder.RenameIndex(
                name: "IX_Albums_ArtistId",
                table: "Album",
                newName: "IX_Album_ArtistId");

            migrationBuilder.AlterColumn<int>(
                name: "Genre",
                table: "Album",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Album",
                table: "Album",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Users_ArtistId",
                table: "Album",
                column: "ArtistId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Users_FanId",
                table: "Album",
                column: "FanId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Album_TrackList_TrackListId",
                table: "Album",
                column: "TrackListId",
                principalTable: "TrackList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
